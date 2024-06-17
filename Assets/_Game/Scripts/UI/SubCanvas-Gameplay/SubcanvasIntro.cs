using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SubcanvasIntro : UICanvas
{
    [SerializeField] TMP_Text description;
    public void SetLevel(string description){
        this.description.text = description;
    }
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
