using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShelfManager : MonoBehaviour
{
    // Start is called before the first frame update
    private Dictionary<System.Type, StackableItem> inventory = new Dictionary<System.Type, StackableItem>();
    [SerializeField] private Transform inventoryDisplay;
    public void Add<T>(T item, int count)where T:StackableItem{
        System.Type itemType = item.GetType();
        if (!inventory.ContainsKey(itemType)){
            StackableItem itemContainer = Instantiate(item, inventoryDisplay);
            itemContainer.transform.SetSiblingIndex(inventory.Count);
            inventory.Add(itemType,itemContainer);
        }
        inventory[itemType].Add(count);
    }

    public bool Remove<T>(T item, int count) where T:StackableItem{
        System.Type itemType = item.GetType();
        if (!inventory.ContainsKey(itemType)){
            return false;
        }
        int result = inventory[itemType].Remove(count);
        if (result == -1){
            return false;
        }
        if (result == 0){
            inventory.Remove(itemType);
        }
        return true;
    }
}
