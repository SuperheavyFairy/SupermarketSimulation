using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Spawner : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] public Transform parent;
    System.Random rand = new System.Random();
    int cooldown  = 5;
    void Start()
    {
        
    }

    void Init(){

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (cooldown == 0){
            cooldown = 40;
        }
        cooldown--;
    }
}
