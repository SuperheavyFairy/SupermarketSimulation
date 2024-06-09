using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShelfManager : MonoBehaviour
{
    // Start is called before the first frame update
    private Dictionary<int, BaseItemShelf> pointer = new Dictionary<int, BaseItemShelf>();
    private BaseItemShelf baseItem;
    [SerializeField] Transform inventoryDisplay;
    [SerializeField] CanvasGameplay parent;
    public void Awake(){
        baseItem = Resources.LoadAll<BaseItemShelf>("Templates")[0];
    }
    public void Add(ItemData item, int count){
        int id = item.id;
        if (!pointer.ContainsKey(id)){
            BaseItemShelf itemContainer = Instantiate(baseItem, inventoryDisplay);
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

    public void Store(int id, ItemData data, int count){
        parent.ToStorage(data, count);
        Remove(id); 
    }
}
