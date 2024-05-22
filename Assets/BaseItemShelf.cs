using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public delegate void RemoveItem(int id);

public class BaseItemShelf : MonoBehaviour
{
    [SerializeField] Image itemImage;
    [SerializeField] TMPro.TextMeshProUGUI itemName;
    [SerializeField] Button itemButton;

    RemoveItem deleteFunc;
    int id;

    public void SetState(Image img, string name, RemoveItem deleteFunc, id int){
        this.itemImage = img;
        this.itemName.text = name;
        this.deleteFunc = RemoveItem;
        this.id = id;
    }

    public void OnClick(){
        RemoveItem(id);
        Destroy(gameObject);
    }
}
