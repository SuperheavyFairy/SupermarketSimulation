using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CanvasGameplay : UICanvas{

    [SerializeField] string levelPrefabPrefix;
    [SerializeField] StorageManager storageManager;
    int Cash;

    public void SetLevel(int level){
        LevelData prefab = Resources.Load<LevelData>("Level/1}");
        childManager.GetUI<SubcanvasIntro>().SetLevel(level);
    }

    public override void Setup(){
        storageManager.SetDisplay(childManager.Open<SubcanvasManagement>().getStorage().getContent());
        childManager.CloseAll();
        childManager.Open<SubcanvasIntro>();
    }

    public void Pause(){
        Time.timeScale = 0;
    }

    public void Unpause(){
        Time.timeScale = 1;
    }

    public void OpenSetting(){
        Pause();
        manager.Open<CanvasSetting>().SetState(this);
    }

    public void OpenIntro(){
        Pause();
        childManager.Open<SubcanvasIntro>();
    }
    
    public void OpenManagement(){
        Pause();
        childManager.Open<SubcanvasManagement>();
        
    }
    
    public void OpenNews(){
        Pause();
        childManager.Open<SubcanvasNews>();
    }

    public void OpenPurchase(){
        Pause();
        childManager.Open<SubcanvasPurchase>();
    }

}