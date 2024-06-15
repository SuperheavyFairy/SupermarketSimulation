using System;
using System.Collections.Generic;
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
    private Transform nextPoint;
    [SerializeField] public float speed = 2;

    // Event
    public EventScript event_;

    // Customer stuff demand parameters
    [SerializeField] private int foodDemandParam = 1;
    [SerializeField] private int drinkDemandParam = 1;
    [SerializeField] private int clothesDemandParam = 2;

    // Customer maximum price acceptance 
    [SerializeField] private int deltaPrice = 10;
    private int maxPriceFood;
    private int maxPriceDrink;
    private int maxPriceClothes;

    // Customer maximum products buying
    [SerializeField] private int deltaProducts = 1;
    private int maxNumberFood;
    private int maxNumberDrink;
    private int maxNumberClothes;

    public CustomerScript(EventScript event_)
    {
        this.event_ = event_;

        if (event_.GetType == EventType.Covid)
        {
            foodDemandParam += event_.GetFoodFactor * event_.GetSeverity;
            drinkDemandParam += event_.GetDrinkFactor * event_.GetSeverity;

        }
        else if (event_.GetType == EventType.Drought)
        {
            drinkDemandParam += event_.GetDrinkFactor * event_.GetSeverity;
        }
        // Customer maximum price acceptance
        maxPriceFood = 30 + deltaPrice * foodDemandParam;
        maxPriceDrink = 20 + deltaPrice * drinkDemandParam;
        maxPriceClothes = 50 + deltaPrice * clothesDemandParam;

        // Customer maximum products buying
        maxNumberFood = 1 + deltaProducts * foodDemandParam;
        maxNumberDrink = 1 + deltaProducts * drinkDemandParam;
        maxNumberClothes = 1 + deltaProducts * clothesDemandParam;
    }


    void Awake()
    {
        myRoute = routes.routes[UnityEngine.Random.Range(0, routes.routes.Count)];
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
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
                Destroy(gameObject);
                return;
            }
            nextPoint = myRoute[nextPointIndex].transform;
            rb.velocity = velocities[nextPointIndex-1];
            anim.SetBool(GetDirection(velocities[nextPointIndex-1]), true);
            anim.SetBool(GetDirection(velocities[nextPointIndex-2]), false);
        }

        // if (transform.position.x > 3700 || transform.position.x < -3700 || transform.position.y > 1400 || transform.position.y < -1400)
        // {
        //     Destroy(gameObject);
        // }
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
