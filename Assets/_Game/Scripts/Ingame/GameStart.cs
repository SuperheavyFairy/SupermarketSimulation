using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStart : MonoBehaviour
{   
    [SerializeField] UIManager manager;
    // Start is called before the first frame update
    int score=0;
    void Start()
    {
        manager.Open<CanvasMainMenu>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
