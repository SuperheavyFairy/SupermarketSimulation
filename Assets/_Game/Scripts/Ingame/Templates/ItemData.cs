using System.Collections;
using System.Collections.Generic;
using UnityEngine;


enum ItemGroup{
    Food,
    Drink,
    Clothes
}
public class ItemData : MonoBehaviour
{
    public int id;
    public string Name;
    public string Description;
    public int basePrice, price;
    [SerializeField] internal ItemGroup[] Groups;
}
