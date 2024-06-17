using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThiefEventScript : BaseEventScript
{
    [SerializeField] CustomerScript thief;
    void Awake(){
        duration = 1;
    }
    public override void EventEnd()
    {
        //Apply increase cooldown by 2;
        CanvasGameplay top = GetComponentInParent<CanvasGameplay>();
        thief.OnExit();
    }

    public override void EventStart()
    {
        //Apply increase cooldown by 2;
        CanvasGameplay top = GetComponentInParent<CanvasGameplay>();
        thief = top.spawner.Spawn(thief);
        thief.AddHook("RemoveItem", "OnExit", Steal);
    }
    private void Steal(CustomerScript thief){
        thief.ItemBrought.Clear();
        thief.TotalCost = 0;
    }

    public override void EventTick()
    {
        
    }
}

