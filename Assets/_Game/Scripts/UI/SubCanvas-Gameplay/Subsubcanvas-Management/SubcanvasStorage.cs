using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubcanvasStorage : UICanvas
{
    [SerializeField] Transform content;
    public Transform getContent(){
        return content;
    }
}
