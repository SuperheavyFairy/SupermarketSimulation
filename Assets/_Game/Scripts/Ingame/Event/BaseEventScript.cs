using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseEventScript : MonoBehaviour
{
    public EventScript eventScript;
    public int severity;
    // Start is called before the first frame update
    void Start()
    {
        eventScript = new EventScript(EventType.Drought, severity);
    }

}
