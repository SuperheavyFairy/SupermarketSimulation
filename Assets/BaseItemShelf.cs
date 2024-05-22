using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public delegate void RemoveItem(int id);

public class BaseItemShelf : MonoBehaviour
{
    [SerializeField] Image itemImage;
    [SerializeField] TMPro.TextMeshProUGUI itemName;
    [SerializeField] Button itemButton;

    RemoveItem deleteFunc;
    int id;

    public void SetState(Image img, string name, RemoveItem deleteFunc, int id){
        this.itemImage = img;
        this.itemName.text = name;
        this.deleteFunc = deleteFunc;
        this.id = id;
    }

    public void OnClick(){
        deleteFunc(id);
        Destroy(gameObject);
    }
}
