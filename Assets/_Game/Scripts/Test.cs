using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    // Start is called before the first frame update
    int score=0;
    void Start()
    {
        UIManager.Instance.Open<CanvasMainMenu>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q) && UIManager.Instance.IsOpened<CanvasGameplay>()){
            UIManager.Instance.GetUI<CanvasGameplay>().UpdateCoin(++score);
        }
    }
}
