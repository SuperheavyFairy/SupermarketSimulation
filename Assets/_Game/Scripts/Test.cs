using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    [SerializeField] private StorageManager inventory;
    // Start is called before the first frame update
    int cooldown = 20;
    int currentCooldown = 20;
    void Awake()
    {
        Time.fixedDeltaTime = 1f/20;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        currentCooldown--;
        if(currentCooldown>0){
            return;
        }
        
        currentCooldown = 20;
    }
}
