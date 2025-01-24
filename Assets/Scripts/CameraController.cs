using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform _player;
    [SerializeField] private float _aHeadDis;
    [SerializeField] private float _cameraSpeed;
    /*[SerializeField]*/ private float _lookAhead = 0;
    private float lastLookAhead;

    void Update()
    {
        transform.position = new Vector3(_player.position.x + _lookAhead, _player.position.y, transform.position.z);
        if (_lookAhead <= 5f && _lookAhead >= -5f)
        {
            _lookAhead = Mathf.Lerp(_lookAhead, (_aHeadDis * _player.localPosition.x), Time.deltaTime * _cameraSpeed);
 //           _lookAhead = Mathf.RoundToInt(_lookAhead);
 //           lastLookAhead = _lookAhead;
        }
 //       else if (_lookAhead >5f)
 //       {
 //           _lookAhead = 5f;
 //       }
 //       else
 //       {
 //           _lookAhead = -5f;
 //       }
    }
}
