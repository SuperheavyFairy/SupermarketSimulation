using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class BaseItemStore : MonoBehaviour
{
    [SerializeField] Transform itemImage, content;
    [SerializeField] TMPro.TextMeshProUGUI itemName, price;
    [SerializeField] Button buyButton;

    RemoveItem deleteFunc;
    int id;

    public void SetState(Image img, string name, RemoveItem deleteFunc, int id){
        Instantiate(img, itemImage);
        this.itemName.text = name;
        this.deleteFunc = deleteFunc;
        this.id = id;
    }

    public void OnClick(){
        deleteFunc(id);
        Destroy(gameObject);
    }
}
