using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Transitions : MonoBehaviour
{
    public GameObject tilemap;
    private void Awake()
    {
        PubSub.RegisterListener<AfterFirstBossEvent>(OpenDoor);
    }

    private void OpenDoor(object publishedEvent)
    {
        AfterFirstBossEvent e = publishedEvent as AfterFirstBossEvent;
        tilemap.SetActive(false);
    }
}
