using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class BaseItemStorage : MonoBehaviour
{
    [SerializeField] Transform itemImage;
    [SerializeField] TMP_Text itemName, countText;
    [SerializeField] TMP_InputField price;
    [SerializeField] TMP_Text content;

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
        this.content.text = item.Description;
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
        UpdateCount();
        if (this.count == 0){
            parent.Remove(id);
        }
        return true;
    }

    public void OnClickAdd(){
        int priceInt;
        if(int.TryParse(price.text, out int result)){
            priceInt = result;   
        }else{
            Debug.Log($"Attempted conversion of {price.text} failed");
            return;
        }
        parent.Show(id, data, priceInt, count);
    }

    public void OnclickRemove(){
        parent.Remove(id);
    }
}
