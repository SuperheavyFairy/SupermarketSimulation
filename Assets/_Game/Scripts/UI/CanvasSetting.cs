using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasSetting : UICanvas{

    [SerializeField] GameObject[] buttons;

    public void SetState(UICanvas canvas){
        for (int i = 0; i < buttons.Length; i++){
            buttons[i].gameObject.SetActive(false);
        }
        if (canvas is CanvasMainMenu){
            buttons[0].gameObject.SetActive(true);
        }else if (canvas is CanvasGameplay)
        {
            buttons[1].gameObject.SetActive(true);
            buttons[2].gameObject.SetActive(true);
        }
    }

    public void CloseButton(){
        Close(0);
    }

    public void MainMenuButton(){
        manager.CloseAll();
        manager.Open<CanvasMainMenu>();
    }
}
