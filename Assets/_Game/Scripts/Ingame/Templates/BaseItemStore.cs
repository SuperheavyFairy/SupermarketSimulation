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
    }

    public void SetParent(StoreManager parent){
        this.parent = parent;
    }


    public void OnClickBuy(){
        int count;
        if(int.TryParse(numberBrought.text, out int result)){
            count = result;   
        }else{
            Debug.Log($"Attempted conversion of {numberBrought.text} failed");
            return;
        }
        parent.Buy(data, count);
    }
}
