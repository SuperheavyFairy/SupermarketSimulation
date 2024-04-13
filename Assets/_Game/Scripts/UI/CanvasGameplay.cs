using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CanvasGameplay : UICanvas{
    [SerializeField] TMPro.TextMeshProUGUI coinText;


    public override void Setup(){
        UpdateCoin(0);
    }
    public void UpdateCoin(int coin) {
        coinText.text = coin.ToString();
    }

    public void SettingButton(){
        UIManager.Instance.Open<CanvasSetting>();
    }
}