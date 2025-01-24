using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerAttack : MonoBehaviour
{   
    public bool flag = true;
    [SerializeField] private GameObject projectile;    
    [SerializeField] private RectTransform mainCanvasRectTr;  
    [SerializeField] private int dirCoef;
    [SerializeField] private float _damage;
    [SerializeField] private float colldownTimer;
    [SerializeField] private float _speed;
    private Vector3 rectTransformDelta;
    private Vector3 targetPosition;
    private Vector3 direction;
    private GameObject buffer;
    private SpriteRenderer sr;
    private Vector3 spawnPoint;
    private PlayerMove playerMove;
    private Rigidbody2D rbProjectile;
    private float angle;  

    void Awake()
    {
        playerMove = GetComponent<PlayerMove>();
        sr = GetComponent<SpriteRenderer>();
        
    }

    private void Start()
    {
        rectTransformDelta = mainCanvasRectTr.sizeDelta;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) 
        {
            if (flag)
            {
                playerMove.ChangeAnimation("Attack");
            }
        }
    }
    private void SpawnProjectile(int dirCoef)
    {
        targetPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        targetPosition.z = 0;
        spawnPoint = transform.position + new Vector3(1.5f * dirCoef, 1, 0);
        buffer = Instantiate(projectile, spawnPoint, Quaternion.identity);
        direction = (targetPosition - spawnPoint).normalized;
        angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        buffer.transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
        buffer.GetComponent<ProjectileStats>().SetDamage(_damage);
        rbProjectile = buffer.GetComponent<Rigidbody2D>();
        if (rbProjectile != null)
        {
            rbProjectile.velocity = direction * _speed;   
        }
        //buffer.transform.Rotate(0, 0, angle);
        //buffer.GetComponent<ProjectileMove>().ChangeDirection();            
        StartCoroutine(CooldownAttack());      
    }
    public void CheckRotation() // must have
    {
        if (sr.flipX == false)
        {
            SpawnProjectile(dirCoef);
        }
        else
        {
            SpawnProjectile(-dirCoef);
        }
    }
    private IEnumerator CooldownAttack()
    {
        flag = false;
        yield return new WaitForSeconds(colldownTimer);
        flag = true;
    }
}
