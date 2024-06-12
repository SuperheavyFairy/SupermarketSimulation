using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class BaseItemShelf : MonoBehaviour
{
    [SerializeField] Transform itemImage;
    [SerializeField] TMPro.TextMeshProUGUI itemName, countText;
    [SerializeField] Button itemButton;
    
    int id, count;
    ShelfManager parent;
    ItemData data;

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

    public void SetParent(ShelfManager parent){
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

    public void OnClick(){
        parent.Store(id, data, count);
    }
}
