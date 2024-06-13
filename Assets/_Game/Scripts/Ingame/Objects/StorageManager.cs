using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StorageManager : MonoBehaviour
{
    // Start is called before the first frame update
    private Dictionary<int, BaseItemStorage> pointer = new Dictionary<int, BaseItemStorage>();
    private BaseItemStorage baseItem;
    [SerializeField] Transform inventoryDisplay;
    [SerializeField] CanvasGameplay parent;
    public void Awake(){
        baseItem = Resources.LoadAll<BaseItemStorage>("Templates")[0];
    }

    public void SetDisplay(Transform parent){
        this.inventoryDisplay = parent;
    }
    public void Add(ItemData item, int count){
        int id = item.id;
        if (!pointer.ContainsKey(id)){
            BaseItemStorage itemContainer = Instantiate(baseItem, inventoryDisplay);
            itemContainer.SetState(item);
            itemContainer.SetParent(this);
            itemContainer.transform.SetSiblingIndex(pointer.Count);
            pointer.Add(id, itemContainer);
        }
        pointer[id].Add(count);
    }

    public bool Remove(int id, int count){
        if (!pointer.ContainsKey(id)){
            return false;
        }
        return pointer[id].Remove(count);
    }

    public bool Remove(int id){
        if (!pointer.ContainsKey(id)){
            return false;
        }
        Destroy(pointer[id].gameObject);
        pointer.Remove(id);
        return true;
    }

    public void Show(int id, ItemData data, int price, int count){
        data.price = price;
        parent.ToShelf(data, count);
        Remove(id); 
    }
}
