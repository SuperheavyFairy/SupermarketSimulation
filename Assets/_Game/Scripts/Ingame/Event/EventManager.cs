using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    private Dictionary<BaseEventScript, int> currentEvents = new Dictionary<BaseEventScript, int>();
    public void StartEvent(BaseEventScript eventScript){
        eventScript.EventStart();
        currentEvents.Add(eventScript, eventScript.duration);
    }
    public void OnTick(){
        foreach(var keyValuePair in currentEvents){
            BaseEventScript eventScript = keyValuePair.Key;
            eventScript.EventTick();
            if(--currentEvents[keyValuePair.Key] <= 0){
                eventScript.EventEnd();
                currentEvents.Remove(keyValuePair.Key);
            }
        }
    }
}
