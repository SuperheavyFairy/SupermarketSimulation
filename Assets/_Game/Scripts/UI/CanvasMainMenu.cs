using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasMainMenu : UICanvas{
    [SerializeField] GameObject[] Buttons;

    public void PlayButton(GameObject caller){
        Close(0);
        for (int i = 0; i < Buttons.Length; i++)
        {
            if (caller == Buttons[i]){
                manager.Open<CanvasGameplay>().SetState(i);
            }
        }
    }
    public void SettingButton(){
        manager.Open<CanvasSetting>().SetState(this);
    }
}
