using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubcanvasNews : UICanvas
{
    [SerializeField] private Transform parent;
    [SerializeField] private BaseItemReport prefab;
    internal void UpdateStatistic(Dictionary<ItemData, Tuple<int, int, int>> ItemStat, int TotalCustomer){
        if(ItemStat == null){
            return;
        }
        foreach(var item in ItemStat){
            BaseItemReport itemReport = Instantiate(prefab, parent);
            itemReport.SetState(item.Key.Name, item.Value);
        }
    }
}
