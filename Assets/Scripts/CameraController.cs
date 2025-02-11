using Cinemachine;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private CinemachineVirtualCamera _camera;
    [SerializeField] private Transform player;
    private void Awake()
    {
        _camera = GetComponent<CinemachineVirtualCamera>();
        PubSub.RegisterListener<FixCameraBossEvent>(ChangeCameraFollow);
    }

    private void ChangeCameraFollow(object publishedEvent)
    {
        FixCameraBossEvent e = publishedEvent as FixCameraBossEvent;
        if (e.IsPlayerInArea)
        {
            _camera.Follow = e.FixCameraPos;
        }
        else
        {
            _camera.Follow = player;
        }
    }
}
