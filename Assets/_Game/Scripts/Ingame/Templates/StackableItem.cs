using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StackableItem : MonoBehaviour
{
    int count;
    [SerializeField] protected TMPro.TextMeshProUGUI countText;
    void Awake(){
        count = 0;
    }

    void SetCount(int inp){
        count = inp;
        UpdateCount();
    }

    void UpdateCount(){
        countText.text = count.ToString();
    }
    public void Add(int inp){
        count += inp;
        UpdateCount();
    }

    public int Remove(int inp){
        if(count<inp){
            return -1;
        }
        count -= inp;
        if(count==0){
            Destroy(gameObject);
            return 0;
        }
        UpdateCount();
        return 1;
    }
}
