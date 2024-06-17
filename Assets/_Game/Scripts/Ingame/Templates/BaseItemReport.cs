using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BaseItemReport : MonoBehaviour
{
    [SerializeField] TMP_Text itemName, moneySpent, moneyEarn, numCustomer;

    StoreManager parent;

    public void SetState(string itemName, Tuple<int,int,int> itemStat){
        this.itemName.text = itemName;
        this.moneySpent.text = itemStat.Item1.ToString();
        this.moneyEarn.text = itemStat.Item2.ToString();
        this.numCustomer.text = itemStat.Item3.ToString();
    }

    public void SetParent(StoreManager parent){
        this.parent = parent;
    }
}
