using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubcanvasNews : UICanvas
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    internal void UpdateStatistic(Dictionary<ItemData, Tuple<int, int, int>> ItemStat, int TotalCustomer){
        Debug.Log(ItemStat);
        if(ItemStat == null){
            return;
        }
        foreach(var item in ItemStat){
            Debug.Log(item);
        }
        Debug.Log(TotalCustomer);
    }
}
