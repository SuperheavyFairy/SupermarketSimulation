using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EventType { Covid, Theft, Drought };

public class CovidEventScript : BaseEventScript
{
    void Awake(){
        duration = 3600;
    }
    public override void EventEnd()
    {
        //Apply increase cooldown by 2;
        CanvasGameplay top = GetComponentInParent<CanvasGameplay>();
        top.spawner.cooldown /= 2;
    }

    public override void EventStart()
    {
        //Apply increase cooldown by 2;
        CanvasGameplay top = GetComponentInParent<CanvasGameplay>();
        top.spawner.cooldown *= 2;
    }

    public override void EventTick()
    {
        
    }
}

