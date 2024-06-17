using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class StoreManager : MonoBehaviour
{
    // Start is called before the first frame update
    private Dictionary<int, BaseItemStore> pointer = new Dictionary<int, BaseItemStore>();
    private BaseItemStore baseItem;
    [SerializeField] Transform inventoryDisplay;
    [SerializeField] CanvasGameplay parent;
    private ItemData[] itemDatas;
    public void Awake(){
        baseItem = Resources.LoadAll<BaseItemStore>("Templates")[0];
        itemDatas = Resources.LoadAll<ItemData>("Items/ItemsData");
    }

    public void SetDisplay(Transform parent){
        //Remove all old display
        var tmp = pointer.Keys.ToListPooled();
        foreach (int id in tmp){
            Remove(id);
        }
        this.inventoryDisplay = parent;
        foreach (ItemData item in itemDatas){
            Add(item);
        }

    }
    public void Add(ItemData item){
        int id = item.id;
        if (!pointer.ContainsKey(id)){
            BaseItemStore itemContainer = Instantiate(baseItem, inventoryDisplay);
            itemContainer.SetState(item);
            itemContainer.SetParent(this);
            itemContainer.transform.SetSiblingIndex(pointer.Count);
            pointer.Add(id, itemContainer);
        }
    }

    public bool Remove(int id){
        if (!pointer.ContainsKey(id)){
            return false;
        }
        Destroy(pointer[id].gameObject);
        pointer.Remove(id);
        return true;
    }

    public void Buy(ItemData data, int count){
        if(data.basePrice*count > parent.cash){
            return;
        }
        Debug.Log(data.basePrice*count);
        parent.cash -= data.basePrice*count;
        parent.ToStorage(data, count);
    }
}
