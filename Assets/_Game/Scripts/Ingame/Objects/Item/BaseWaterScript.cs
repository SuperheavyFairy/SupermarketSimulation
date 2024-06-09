using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseWaterScript : MonoBehaviour
{
    [SerializeField] public WaterScript water;
    [SerializeField] public int importPrice;
    // Start is called before the first frame update
    void Start()
    {
        this.water = new WaterScript(importPrice);
    }

}
