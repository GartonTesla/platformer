using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : MonoBehaviour
{
    [SerializeField] private float HP;
    [SerializeField] private float MaxHP;
    private GameObject otherGameObject;
    void Start()
    {
        HP = MaxHP;
    }



    public void TakeDamage(float prDamage)
    {
        if (HP > 0)
        {
            HP -= prDamage;
            if (HP <= 0)
            {
                gameObject.SetActive(false);
            }
        }
    }
}
