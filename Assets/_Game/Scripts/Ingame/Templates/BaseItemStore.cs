using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class BaseItemStore : MonoBehaviour
{
    [SerializeField] Transform itemImage, content;
    [SerializeField] TMPro.TextMeshProUGUI itemName, price, numberBrought;
    [SerializeField] Button buyButton;

    int id;

    ItemData data;

    StoreManager parent;

    public void SetState(ItemData item){
        this.data = item;
        this.id = id;
        Instantiate(item.gameObject, itemImage);
        this.itemName.text = item.name;
        this.price.text = item.basePrice.ToString();
    }

    public void SetParent(StoreManager parent){
        this.parent = parent;
    }


    public void OnClickBuy(){
        Debug.Log("OnClickBuy");
        numberBrought.Clear();
        Debug.Log(Convert.FromBase64String(numberBrought.text));
        int count;
        if(int.TryParse(numberBrought.text.Trim(), out int result)){
            count = result;   
        }else{
            Debug.Log($"[{numberBrought.text}]");
            return;
        }
        parent.Buy(data, count);
    }
}
