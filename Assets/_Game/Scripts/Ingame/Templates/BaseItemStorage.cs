using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class BaseItemStorage : MonoBehaviour
{
    [SerializeField] Transform itemImage;
    [SerializeField] TMPro.TextMeshProUGUI itemName, countText, price;
    [SerializeField] Transform content;

    int id, count;

    ItemData data;

    StorageManager parent;

    private void UpdateCount(){
        this.countText.text = ""+count;
    }
    public void SetState(ItemData item){
        this.data = item;
        this.count = 0;
        this.id = item.id;
        Instantiate(item.gameObject, itemImage);
        this.itemName.text = item.name;
    }

    public void Add(int count){
        this.count += count;
        UpdateCount();
    }

    public void SetParent(StorageManager parent){
        this.parent = parent;
    }

    public bool Remove(int count){
        if (count > this.count){
            return false;
        }
        this.count -= count;
        if (this.count == 0){
            parent.Remove(id);
        }
        return true;
    }

    public void OnClickAdd(){
        int priceInt;
        string raw = price.text;
        Debug.Log(raw.Length);
        string cleaned = raw.Substring(0, raw.Length-2);
        if(int.TryParse(cleaned, out int result)){
            priceInt = result;   
        }else{
            Debug.Log($"Attempted conversion of {cleaned} failed");
            return;
        }
        parent.Show(id, data, priceInt, count);
    }

    public void OnclickRemove(){
        parent.Remove(id);
    }
}
