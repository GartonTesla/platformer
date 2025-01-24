using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossStats : MonoBehaviour
{
    [SerializeField] private float HP;
    [SerializeField] private float MaxHP;
    private Animator animator;
    private GameObject otherGameObject;
    private BossMovement bm;
    
    
    
    void Start()
    {
        bm = GetComponent<BossMovement>();
        animator = GetComponent<Animator>();
        HP = MaxHP;
    }



    public void TakeDamage(float prDamage)
    {
        if (HP > 0)
        {
            HP -= prDamage;
        }
        if (HP <= 0)
        {
            bm.OnDeath();
            animator.Play("Death");
        }
    }
    public void Death()
    {
        gameObject.SetActive(false);
    }
}
