using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Threading;
using Unity.VisualScripting;
using UnityEngine;

public class ShelfManager : MonoBehaviour
{
    // Start is called before the first frame update
    private Dictionary<int, BaseItemShelf> pointer = new Dictionary<int, BaseItemShelf>();
    private BaseItemShelf baseItem;
    [SerializeField] Transform[] inventoryDisplay;
    [SerializeField] CanvasGameplay parent;
    public void Awake(){
        baseItem = Resources.LoadAll<BaseItemShelf>("Templates")[0];
    }
    public void Add(ItemData item, int count){
        int id = item.id;
        shelfMutex.WaitOne();
        if (!pointer.ContainsKey(id)){
            BaseItemShelf itemContainer = Instantiate(baseItem, inventoryDisplay[(int)item.Groups[0]]);
            itemContainer.SetState(item);
            itemContainer.SetParent(this);
            pointer.Add(id, itemContainer);
        }
        pointer[id].Add(count);
        shelfMutex.ReleaseMutex();
    }

    public bool Remove(int id, int count){
        if (!pointer.ContainsKey(id)){
            return false;
        }
        shelfMutex.WaitOne();
        bool result = pointer[id].Remove(count);
        shelfMutex.ReleaseMutex();
        return result;
    }

    public bool Remove(int id){
        if (!pointer.ContainsKey(id)){
            return false;
        }
        shelfMutex.WaitOne();
        Destroy(pointer[id].gameObject);
        pointer.Remove(id);
        shelfMutex.WaitOne();
        return true;
    }

    public void Store(int id, ItemData data, int count){
        parent.ToStorage(data, count);
        Remove(id); 
    }

    private static Mutex shelfMutex = new Mutex();
    public void PickItem(CustomerScript customer){
        shelfMutex.WaitOne();
        var tmp = pointer.Values.ToArrayPooled();
        foreach(BaseItemShelf item in tmp){
            int itemNum = customer.ChooseItem(item.data, item.count);
            item.Remove(itemNum);
        }
        shelfMutex.ReleaseMutex();
    }
}
