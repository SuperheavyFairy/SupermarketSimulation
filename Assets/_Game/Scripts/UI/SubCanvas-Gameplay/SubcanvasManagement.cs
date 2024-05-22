using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubcanvasManagement : UICanvas
{
    private void Start(){
        childManager.Open<SubcanvasStorage>();
    }
    public SubcanvasStorage getStorage(){
        return childManager.GetUI<SubcanvasStorage>();
    }
    public void OpenStorage(){
        Debug.Log("Storage");
        childManager.CloseAll();
        childManager.Open<SubcanvasStorage>();
    }

    public void OpenEmployee(){
        Debug.Log("Employee");
        childManager.CloseAll();
        childManager.Open<SubcanvasEmployee>();
    }
}
