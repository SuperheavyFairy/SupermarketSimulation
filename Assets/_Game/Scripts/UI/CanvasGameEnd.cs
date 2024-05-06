using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasGameEnd : UICanvas{
    public void MainMenuButton(){
        Close(0);
        manager.Open<CanvasMainMenu>();
    }
}