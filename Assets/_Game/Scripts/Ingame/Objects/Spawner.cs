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
    int cooldown  = 5;
    void Awake()
    {
        customers[0].routes = routes;
    }

    void Init(){

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (cooldown == 0){
            cooldown = 40;
            Instantiate(customers.Last(), parent);
        }
        cooldown--;
    }
}
