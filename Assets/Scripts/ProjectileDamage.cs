using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngineInternal;

public class ProjectileDamage : MonoBehaviour
{
    private ProjectileStats projectileStats;
    private Animator animator;
    private float damage;
    private Rigidbody2D rb;
    private BoxCollider2D bC;
    void Start()
    {
        projectileStats = GetComponent<ProjectileStats>();
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        bC = GetComponent<BoxCollider2D>();
        damage = projectileStats.GetDamage();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            animator.Play("ProjectileDeath");
            rb.constraints = RigidbodyConstraints2D.FreezePosition;
            bC.enabled = false;
            collision.gameObject.GetComponent<EnemyStats>().TakeDamage(damage);
        }
        if (collision.gameObject.tag == "Boss")
        {
            animator.Play("ProjectileDeath");
            rb.constraints = RigidbodyConstraints2D.FreezePosition;
            bC.enabled = false;
            collision.gameObject.GetComponent<BossStats>().TakeDamage(damage);
        }
    }
    public void ProjDeath()
    {
        Destroy(gameObject);
    }
}
