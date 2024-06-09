using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseClothesScript : MonoBehaviour
{
    [SerializeField] public ClothesScript clothes;
    [SerializeField] public int importPrice;
    // Start is called before the first frame update
    void Start()
    {
        this.clothes = new ClothesScript(importPrice);
    }

}
