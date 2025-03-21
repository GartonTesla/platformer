using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Threading;
using UnityEditor.Tilemaps;
using UnityEngine;

public class BossMovement : MonoBehaviour
{
    private Transform tr;
    private CapsuleCollider2D cc;
    [SerializeField] private float _speed;
    private GameObject otherGameObject;
    private bool isEdgeReachedLeft = true;
    private bool isEdgeReachedRight;
    private SpriteRenderer sr;
    private bool isWalked = true;
    private float walkTime;
    private bool isCoroutineStarted;
    private bool isLive = true;
    private Animator animator;
    [SerializeField] private GameObject BossRay;
    [SerializeField] private PlayerInZone PlayerInZone;
    [SerializeField] private PlayerInMeleeZone PlayerInMeleeZone;
    [SerializeField] private GameObject Player;
    [SerializeField] private int damage;
    private bool isPlayerInZone;
    private bool isPlayerInMeleeZone;
    private bool isPlayerBehindBoss;



    void Start()
    {
        tr = GetComponent<Transform>();
        sr = GetComponent<SpriteRenderer>();
        cc = GetComponent<CapsuleCollider2D>();
        animator = GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        if (isLive)
        {
            if (isWalked)
            {
                animator.Play("Walk");
                EnemyMove();
            }
        }

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
        if (isCoroutineStarted == false)
        {
            StartCoroutine(WalkTimer());
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        otherGameObject = collision.gameObject;
        if (otherGameObject.tag == "Enemy_border")
        {
            isEdgeReachedLeft = !isEdgeReachedLeft;
            isEdgeReachedRight = !isEdgeReachedRight;
            BossFlip();
        }
    }
    private void BossFlip()
    {
            if (sr.flipX)
            {
                tr.position += new Vector3(-9.65f, 0, 0);
                cc.offset *= new Vector2(-1f, 1);
            }
            if (!sr.flipX)
            {
                tr.position += new Vector3(9.65f, 0, 0);
                cc.offset *= new Vector2(-1f, 1);
            }
            sr.flipX = !sr.flipX;
    }
    private void BossFlipAnim()
    {
        if (isPlayerBehindBoss)
        {
            BossFlip();
            isPlayerBehindBoss = false;
        }
    }
    public void OnDeath()
    {
        PubSub.Publish(new AfterFirstBossEvent() { });
        isLive = false;
    }
    public void OnCast()
    {
        isWalked = true;
    }
    public void RayCast()
    {
        BossRay.SetActive(true);
        BossRay.transform.position = new Vector2(PlayerInZone.CheckPosition().x, BossRay.transform.position.y);
    }
    public void MeleeCast()
    {
        if (isPlayerInMeleeZone)
        {
            PubSub.Publish(new SpikeCollEvent() { Damage = damage });
        }
    }

    IEnumerator WalkTimer()
    {
        isCoroutineStarted = true;
        Debug.Log(isWalked);
        isWalked = true;
        walkTime = Random.Range(3, 5);
        yield return new WaitForSeconds(walkTime);
        Debug.Log("Спавн луча");
        isPlayerInZone = PlayerInZone.CheckPlayerInZone();
        isPlayerInMeleeZone = PlayerInMeleeZone.CheckPlayerInMeleeZone();
        isWalked = false;
        Attack();
        //MeleeAttack();
        //isWalked = false;
        //RangeAttack();
        Debug.Log(isWalked);
        isCoroutineStarted = false;
    }
    private void RangeAttack()
    {
        if (isPlayerInZone)
        {
            if (isLive)
            {
                animator.Play("Cast");
            }
        }
        else
        {
            isWalked = true;
        }
    }
    private void MeleeAttack()
    {
        if (isPlayerInMeleeZone)
        {
            if (isLive)
            {
                if ((PlayerInMeleeZone.CheckPosition().x + 4.65f < transform.position.x && sr.flipX == true) 
                    || (PlayerInMeleeZone.CheckPosition().x - 4.65f > transform.position.x && sr.flipX == false))
                {
                    isPlayerBehindBoss = true;
                    BossFlip();
                    animator.Play("Attack");
                }
                else
                {
                    animator.Play("Attack");
                }
            }
        }
        else
        {
            isWalked = true;
        }
    }
    private void Attack() 
    {
        if (isPlayerInMeleeZone)
        {
            MeleeAttack();
            return;
        }
        else
        {
            RangeAttack();
            return;
        }
    }
}
