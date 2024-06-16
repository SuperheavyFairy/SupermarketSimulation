using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CanvasGameplay : UICanvas{

    [SerializeField] string levelPrefabPrefix;
    [SerializeField] ShelfManager shelfManager;
    [SerializeField] StorageManager storageManager;
    [SerializeField] StoreManager storeManager;
    [SerializeField] Spawner spawner;
    public TMPro.TextMeshProUGUI cashText;
    public int cash;
    private int currentTick;
    private int tickPerSecond = 20;
    private int tickPerMonth = 1800;

    [SerializeField] public Image clock_image;
    [SerializeField] public TMP_Text clock_text;
    

    public void Awake(){
        Time.fixedDeltaTime = 1f/tickPerSecond;
        currentTick = 0;
    }
    public void Update(){
        cashText.text = cash.ToString();
        clock_image.fillAmount = (float)(currentTick%tickPerMonth)/tickPerMonth;
        clock_text.text = (currentTick/tickPerMonth+1).ToString();
    }

    public void FixedUpdate(){
        currentTick += 1;
        spawner.OnTick();
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