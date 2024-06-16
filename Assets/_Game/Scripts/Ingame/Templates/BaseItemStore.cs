using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class BaseItemStore : MonoBehaviour
{
    [SerializeField] Transform itemImage, content;
    [SerializeField] TMP_Text itemName, price;
    [SerializeField] TMP_InputField numberBrought;
    [SerializeField] Button buyButton;

    int id;

    ItemData data;

    StoreManager parent;

    public void SetState(ItemData item){
        this.data = item;
        this.id = item.id;
        Instantiate(item.gameObject, itemImage);
        this.itemName.text = item.name;
        this.price.text = item.basePrice.ToString();
    }

    public void SetParent(StoreManager parent){
        this.parent = parent;
    }


    public void OnClickBuy(){
        int count;
        if(int.TryParse(numberBrought.text, out int result)){
            count = result;   
        }else{
            Debug.Log($"[{numberBrought.text}]");
            return;
        }
        parent.Buy(data, count);
    }
}
