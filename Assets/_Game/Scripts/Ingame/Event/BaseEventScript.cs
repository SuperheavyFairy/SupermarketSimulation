using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseEventScript : MonoBehaviour
{
    public int duration;
    public abstract void EventStart();
    public abstract void EventTick();
    public abstract void EventEnd();
}
