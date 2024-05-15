using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    [SerializeField] private InventoryManager inventory;
    // Start is called before the first frame update
    int cooldown = 20;
    int currentCooldown = 20;
    StackableItem prefab;
    void Awake()
    {
        prefab = Resources.LoadAll<StackableItem>("Goods")[0];
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        currentCooldown--;
        if(currentCooldown>0){
            return;
        }
        inventory.Add(prefab, 1);
        currentCooldown = 20;
    }
}
