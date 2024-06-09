using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseMeatScript : MonoBehaviour
{
    [SerializeField] public MeatScript meat;
    [SerializeField] public int importPrice;
    // Start is called before the first frame update
    void Start()
    {
        this.meat = new MeatScript(importPrice);
    }

}
