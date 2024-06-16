using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasGameplay : UICanvas{

    [SerializeField] string levelPrefabPrefix;
    [SerializeField] ShelfManager shelfManager;
    [SerializeField] StorageManager storageManager;
    [SerializeField] StoreManager storeManager;
    public TMPro.TextMeshProUGUI cashText;
    public int cash;


    public void Update(){
        cashText.text = cash.ToString();
    }
    public void SetLevel(int level){
        LevelData prefab = Resources.Load<LevelData>("Level/1}");
        childManager.GetUI<SubcanvasIntro>().SetLevel(level);
    }

    public override void Setup(){
        cash = 10000000;
        storageManager.SetDisplay(childManager.Open<SubcanvasManagement>().getStorage().getContent());
        storeManager.SetDisplay(childManager.Open<SubcanvasPurchase>().getDisplay());
        childManager.CloseAll();
        OpenIntro();
    }

    public void Pause(){
        Time.timeScale = 0;
    }

    public void Unpause(){
        Time.timeScale = 1;
    }

    public void OpenSetting(){
        Pause();
        manager.Open<CanvasSetting>().SetState(this).AddHook("Unpause", "OnClose", Unpause);
    }

    public void OpenIntro(){
        Pause();
        childManager.Open<SubcanvasIntro>().AddHook("Unpause", "OnClose", Unpause);
    }
    
    public void OpenManagement(){
        Pause();
        childManager.Open<SubcanvasManagement>().AddHook("Unpause", "OnClose", Unpause);
        
    }
    
    public void OpenNews(){
        Pause();
        childManager.Open<SubcanvasNews>().AddHook("Unpause", "OnClose", Unpause);
    }

    public void OpenPurchase(){
        Pause();
        childManager.Open<SubcanvasPurchase>().AddHook("Unpause", "OnClose", Unpause);
    }

    public void ToShelf(ItemData data, int count){
        shelfManager.Add(data, count);
    }
    public void ToStorage(ItemData data, int count){
        storageManager.Add(data, count);
    }
}