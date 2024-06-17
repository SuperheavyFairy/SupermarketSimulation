using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseEventScript : MonoBehaviour
{
    public int duration;
    public SpriteRenderer icon;
    public abstract void EventStart();
    public abstract void EventTick();
    public abstract void EventEnd();
}
