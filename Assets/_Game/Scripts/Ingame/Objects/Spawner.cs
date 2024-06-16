using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;

public class Spawner : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private Transform parent;
    System.Random rand = new System.Random();
    [SerializeField] List<CustomerScript> customers;
    [SerializeField] CustomerRouteScript routes;
    [SerializeField] ShelfManager shelf;
    int cooldown  = 5;
    void Awake()
    {
        customers[0].routes = routes;
        hookAllowed.Add("OnSpawn");
    }

    void Init(){

    }

    // Update is called once per frame
    void Spawn(CustomerScript prefab){
        CustomerScript customer = Instantiate(prefab, parent);
        callHook("OnSpawn", customer);
        shelf.PickItem(customer);
    }
    public void OnTick()
    {
        if (cooldown == 0){
            cooldown = 30;
            Spawn(customers[UnityEngine.Random.Range(0, customers.Count)]);
        }
        cooldown--;
    }

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
    private void callHook(string hookTarget, CustomerScript customer){
        foreach(var item in HookFunction){
            if(item.Key.Item2 == hookTarget){
                item.Value(customer);
            }
        }
    }
}
