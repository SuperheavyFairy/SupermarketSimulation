using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseVegetableScript : MonoBehaviour
{
    [SerializeField] public VegetableScript vegetable;
    [SerializeField] public int importPrice;
    // Start is called before the first frame update
    void Start()
    {
        this.vegetable = new VegetableScript(importPrice);
    }

}
