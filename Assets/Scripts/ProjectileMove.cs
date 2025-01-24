using Cinemachine.Utility;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ProjectileMove : MonoBehaviour
{
    private Rigidbody2D rb;
    private Transform rectTransform;
    private Vector2 _direction;
    private SpriteRenderer sr;
    private float _eulerRotationX;


    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        rectTransform = GetComponent<Transform>();
        sr = GetComponent<SpriteRenderer>();
    }

    //private void FixedUpdate()
    //{
    //    AddVelocityToProjectile();
    //    Debug.Log(_direction + " - _direction");
    //    Debug.Log(rectTransform + " - rectTransform.position.x");
    //}

    //private void AddVelocityToProjectile()
    //{
    //    rb.velocity = Vector2.right * _speed;
    //}

}
