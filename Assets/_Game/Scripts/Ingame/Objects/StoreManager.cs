using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoreManager : MonoBehaviour
{
    // Start is called before the first frame update
    private Dictionary<int, BaseItemStore> pointer = new Dictionary<int, BaseItemStore>();
    private BaseItemStore baseItem;
    [SerializeField] Transform inventoryDisplay;
    [SerializeField] CanvasGameplay parent;
    public void Awake(){
        baseItem = Resources.LoadAll<BaseItemStore>("Templates")[0];
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
        parent.ToStorage(data, count);
    }
}
