using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class UICanvas : MonoBehaviour
{
    [SerializeField] bool isDestroyOnClose = false;
    protected UIManager manager;
    [SerializeField] protected UIManager childManager;
    
    

    private void Awake() {
        RectTransform rect = GetComponent<RectTransform>();
        float ratio = (float) Screen.width / (float) Screen.height;
        if(ratio > 2.1f){
            Vector2 leftBottom = rect.offsetMin;
            Vector2 rightTop = rect.offsetMax;

            leftBottom.y = 0f;
            rightTop.y = -100f;

            rect.offsetMin = leftBottom;
            rect.offsetMax = rightTop;
        }

        hookAllowed.Add("OnClose");
    }
    public virtual void Setup(){

    }

    public virtual void SetManager(UIManager manager){
        this.manager = manager;
    }

    public virtual void Open(){
        gameObject.SetActive(true);
    }
    public void OnClose(){
        callHook("OnClose");
    }
    public virtual void Close(float time){
        Invoke(nameof(CloseDirectly), time);
    }

    public virtual void CloseDirectly(){
        OnClose();
        if(isDestroyOnClose){
            Destroy(gameObject);
        }else{
            gameObject.SetActive(false);
        }
    }
    //Hook Script
    private Dictionary<Tuple<string, string>, Action> HookFunction = new Dictionary<Tuple<string, string>, Action>();
    private List<string> hookAllowed = new List<string>();
    public bool AddHook(string funcName, string hookTarget, Action hook){
        if (!hookAllowed.Contains(hookTarget)){
            return false;
        }
        if(HookFunction.ContainsKey(new Tuple<string, string>(funcName, hookTarget))){
            return false;
        }
        HookFunction.Add(new Tuple<string, string>(funcName, hookTarget), hook);
        return true;
    }
    public bool RemoveHook(string funcName, string hookTarget, Action hook){
        if(HookFunction.ContainsKey(new Tuple<string, string>(funcName, hookTarget))){
            HookFunction.Remove(new Tuple<string, string>(funcName, hookTarget));
            return true;
        }
        return false;
    }
    private void callHook(string hookTarget){
        foreach(var item in HookFunction){
            if(item.Key.Item2 == hookTarget){
                item.Value();
            }
        }
    }
}
