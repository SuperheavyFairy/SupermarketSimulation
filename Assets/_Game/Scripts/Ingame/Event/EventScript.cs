using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EventType { Covid, Theft, Drought };

public class EventScript
{
    private EventType type;
    private int severity;
    private int drinkFactor = 1;
    private int foodFactor = 1;
    private int clothesFactor = 1;

    public EventScript(EventType type, int severity)
    {
        this.type = type;
        this.severity = severity;
        
        if (type == EventType.Drought)
        {
            this.drinkFactor = 2;
        }
    }

    public EventType GetType{
        get {return this.type;}
    }

    public int GetSeverity{
        get {return this.severity;}
    }

    public int GetDrinkFactor{
        get {return this.drinkFactor;}
    }

    public int GetFoodFactor{
        get {return this.foodFactor;}
    }

    public int GetClothesFactor{
        get {return this.clothesFactor;}
    }
}

