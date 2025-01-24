using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.Tilemaps;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private Transform tr;
    [SerializeField] private float _speed;
    private GameObject otherGameObject;
    private bool isEdgeReachedLeft = true;
    private bool isEdgeReachedRight;
    private SpriteRenderer sr;

    void Start()
    {
        tr = GetComponent<Transform>();
        sr = GetComponent<SpriteRenderer>();
    }

    void  FixedUpdate()
    {
        EnemyMove();
    }

    private void EnemyMove()
    {
        if (isEdgeReachedLeft)
        {
            tr.localPosition += new Vector3(_speed, 0f, 0f);
        }
        if (isEdgeReachedRight)
        {
            tr.localPosition -= new Vector3(_speed, 0f, 0f);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        otherGameObject = collision.gameObject;
        if (otherGameObject.tag == "Enemy_border")
        {
            isEdgeReachedLeft = !isEdgeReachedLeft;
            isEdgeReachedRight = !isEdgeReachedRight;
            sr.flipX = !sr.flipX;
        }
    }
    }
