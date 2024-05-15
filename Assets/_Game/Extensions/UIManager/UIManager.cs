using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class UIManager : MonoBehaviour
{
    Dictionary<System.Type, UICanvas> canvases = new Dictionary<System.Type, UICanvas>();
    Dictionary<System.Type, UICanvas> canvasPrefabs = new Dictionary<System.Type, UICanvas>();
    [SerializeField] Transform parent;
    [SerializeField] string prefabPrefix;
    [SerializeField] bool preLoaded;

    public void Awake(){
        UICanvas[] prefabs = Resources.LoadAll<UICanvas>(prefabPrefix);
        for (int i = 0; i < prefabs.Length; i++)
        {
            canvasPrefabs.Add(prefabs[i].GetType(), prefabs[i]);
            if (preLoaded){
                UICanvas canvas = Instantiate(prefabs[i], parent);
                canvas.SetManager(this);
                canvases[prefabs[i].GetType()] = canvas;
            }
        }
    }

    public void Print(){
        Debug.Log("Print key");
        foreach (System.Collections.Generic.KeyValuePair<System.Type, UICanvas> key in canvasPrefabs){
            Debug.Log(key);
        }
    }

    //Open canvas
    public T Open<T>() where T : UICanvas{
        T canvas = GetUI<T>();

        canvas.Setup();
        canvas.Open();

        return canvas;
    }

    //Close canvas after time second
    public void Close<T>(float time) where T : UICanvas{
        if (IsLoaded<T>()){
            canvases[typeof(T)].Close(time);
        }
    }

    //Close canvas
    public void CloseDirectly<T>() where T : UICanvas{
        if (IsLoaded<T>()){
            canvases[typeof(T)].CloseDirectly();
        }
    }

    //Check is canvas created
    public bool IsLoaded<T>() where T : UICanvas{
        return canvases.ContainsKey(typeof(T)) && canvases[typeof(T)] != null;
    }

    //Check is canvas opened
    public bool IsOpened<T>() where T : UICanvas{
        return IsLoaded<T>() && canvases[typeof(T)].gameObject.activeSelf;
    }

    public T GetUI<T>() where T : UICanvas{
        if(!IsLoaded<T>()){
            T prefab = GetPrefab<T>();
            T canvas = Instantiate(prefab, parent);
            canvas.SetManager(this);
            canvases[typeof(T)] = canvas;
        }

        return canvases[typeof(T)] as T;
    }

    //Get Prefab
    private T GetPrefab<T>() where T : UICanvas{
        return canvasPrefabs[typeof(T)] as T;
    }

    public void CloseAll(){
        foreach (var canvas in canvases)
        {
            if(canvas.Value != null && canvas.Value.gameObject.activeSelf){
                canvas.Value.Close(0);
            }
        }
    }
}
