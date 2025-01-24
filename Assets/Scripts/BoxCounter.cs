using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxCounter : MonoBehaviour
{
    private int BoxValue;
    private void Awake()
    {
        PubSub.RegisterListener<BoxTakeEvent>(IncreaseValue);
    }

    public void IncreaseValue(object publishedEvent)
    {
        BoxTakeEvent e = publishedEvent as BoxTakeEvent;
        BoxValue += e.Value;
        Debug.Log(BoxValue);
    }
}
