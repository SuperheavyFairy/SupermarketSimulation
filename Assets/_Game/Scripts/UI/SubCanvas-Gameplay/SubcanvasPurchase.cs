using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubcanvasPurchase : UICanvas
{
    [SerializeField] Transform content;
    public Transform getDisplay(){
        return content;
    }
}
