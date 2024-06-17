using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    private Dictionary<BaseEventScript, int> currentEvents = new Dictionary<BaseEventScript, int>();
    private Dictionary<BaseEventScript, int> allEvents = new Dictionary<BaseEventScript, int>();
    private Dictionary<BaseEventScript, SpriteRenderer> currentIcon = new Dictionary<BaseEventScript, SpriteRenderer>();
    [SerializeField] private Transform iconTray; 
    public void Init(List<BaseEventScript> baseEventScripts, List<int> ints){
        for (int i = 0; i < baseEventScripts.Count; i++){
            allEvents.Add(baseEventScripts[i], ints[i]);
        }
    }
    
    public void StartEvent(BaseEventScript eventScript){
        eventScript = Instantiate(eventScript, transform);
        eventScript.EventStart();
        var icon = Instantiate(eventScript.icon, iconTray);
        icon.gameObject.SetActive(true);
        currentIcon.Add(eventScript, icon);
        currentEvents.Add(eventScript, eventScript.duration);
    }

    public void EndEvent(BaseEventScript eventScript){
        eventScript.EventEnd();
        Destroy(eventScript.gameObject);
        Destroy(currentIcon[eventScript].gameObject);
        currentEvents.Remove(eventScript);
    }
    public void OnTick(int currentTick){
        foreach(var keyValuePair in allEvents){
            if(currentTick == keyValuePair.Value){
                StartEvent(keyValuePair.Key);
            }
        } 
        var tmp = currentEvents.ToArrayPooled();
        foreach(var keyValuePair in tmp){
            BaseEventScript eventScript = keyValuePair.Key;
            eventScript.EventTick();
            if(--currentEvents[keyValuePair.Key] <= 0){
                EndEvent(keyValuePair.Key);
            }
        }
    }
}
