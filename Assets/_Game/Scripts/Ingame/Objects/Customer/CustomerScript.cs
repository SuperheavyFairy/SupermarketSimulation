using System;
using System.Collections.Generic;
using Unity.Collections;
using Unity.Collections.LowLevel.Unsafe;
using Unity.VisualScripting;
using UnityEngine;

public class CustomerScript : MonoBehaviour
{   
    // Animation and movement variables

    [SerializeField] public CustomerRouteScript routes;
    private List<GameObject> myRoute;
    private List<Vector2> velocities;
    private int nextPointIndex;
    private Animator anim;
    private Rigidbody2D rb;
    private SpriteRenderer sr;
    private Transform nextPoint;
    public float speed = 2;

    // Customer stuff demand parameters
    void Awake()
    {
        InitAnimation();
        Init(); 
    }

    void Init(){
        TotalCost = 0;
        hookAllowed.Add("OnSpawned");
        hookAllowed.Add("OnExit");
        hookAllowed.Add("Statistic");
    }

    void InitAnimation(){
        myRoute = routes.routes[UnityEngine.Random.Range(0, routes.routes.Count)];
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        nextPointIndex = 1;
        nextPoint = myRoute[nextPointIndex].transform;

        velocities = new List<Vector2>();
        for (int i = 1; i<myRoute.Count; i++)
        {
            Vector2 direction = myRoute[i].transform.position - myRoute[i-1].transform.position;
            velocities.Add(direction.normalized * speed);
        }
        rb.velocity = velocities[nextPointIndex-1];
        anim.SetBool(GetDirection(velocities[nextPointIndex-1]), true);
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector2.Distance(transform.position, nextPoint.position) < 0.1f)
        {
            nextPointIndex++;
            if (nextPointIndex >= myRoute.Count){
                OnExit();
                return;
            }
            nextPoint = myRoute[nextPointIndex].transform;
            rb.velocity = velocities[nextPointIndex-1];
            anim.SetBool(GetDirection(velocities[nextPointIndex-1]), true);
            anim.SetBool(GetDirection(velocities[nextPointIndex-2]), false);
        }
        if (transform.position.y > 1)
        {
            sr.sortingOrder = 4;
        } else{
            sr.sortingOrder = 90;
        }
    }

    private string GetDirection(Vector2 direction)
    {
        if (direction.x > 0)
        {
            return "isRight";
        }
        else if (direction.x < 0)
        {
            return "isLeft";
        }
        else if (direction.y > 0)
        {
            return "isUp";
        }
        else if (direction.y < 0)
        {
            return "isDown";
        }
        return "isIdle";
    }

    public float BaseDemands;
    internal Dictionary<ItemGroup, float> Demands = new Dictionary<ItemGroup, float>();

    // Customer price acceptance 
    public float BasePrice;
    internal Dictionary<ItemGroup, float> PriceMultipliers = new Dictionary<ItemGroup, float>();

    internal List<Tuple<int, ItemData, int>> ItemBrought = new List<Tuple<int, ItemData, int>>();

    internal int TotalCost;

    public int ChooseItem(ItemData item, int count){
        float demand = BaseDemands;
        float expectedPrice = BasePrice;
        foreach(ItemGroup group in item.Groups){
            if(Demands.ContainsKey(group)){
                demand *= Demands[group];
                expectedPrice *= PriceMultipliers[group];
            }
        }
        demand *= PriceFunction(expectedPrice, item.price);
        int itemNum = Math.Min(count, (int)((UnityEngine.Random.Range(0f, 1f)+Math.Floor(demand)>demand)?Math.Floor(demand):Math.Ceiling(demand)));
        ItemBrought.Add(new Tuple<int, ItemData, int>(itemNum, item, item.price));
        TotalCost += itemNum*item.price;
        return itemNum;
    }

    private float PriceFunction(float expectedPrice, float price){
        float x = price/expectedPrice;
        float y = (float)Math.Log(2*x*(float)Math.E)/(2*x);
        return (float)Math.Clamp(y, 0, 1);
    }

    public void OnSpawned(){
        callHook("OnSpawned");
    }
    public void OnExit(){
        callHook("OnExit");
        SendMessageUpwards("AddCash", TotalCost);
        callHook("Statistic");
        Destroy(gameObject);
    }
    //HookScript (But can affect this object)
    private Dictionary<Tuple<string, string>, Action<CustomerScript>> HookFunction = new Dictionary<Tuple<string, string>, Action<CustomerScript>>();
    private List<string> hookAllowed = new List<string>();
    public bool AddHook(string funcName, string hookTarget, Action<CustomerScript> hook){
        if (!hookAllowed.Contains(hookTarget)){
            return false;
        }
        if(HookFunction.ContainsKey(new Tuple<string, string>(funcName, hookTarget))){
            return false;
        }
        HookFunction.Add(new Tuple<string, string>(funcName, hookTarget), hook);
        return true;
    }
    public bool RemoveHook(string funcName, string hookTarget){
        if(HookFunction.ContainsKey(new Tuple<string, string>(funcName, hookTarget))){
            HookFunction.Remove(new Tuple<string, string>(funcName, hookTarget));
            return true;
        }
        return false;
    }
    private void callHook(string hookTarget){
        foreach(var item in HookFunction){
            if(item.Key.Item2 == hookTarget){
                item.Value(this);
            }
        }
    }

}
