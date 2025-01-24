using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileStats : MonoBehaviour
{
    private float _projectileDamage;

    private void Start()
    {
        StartCoroutine(ProjectileDeath());
    }

    public void SetDamage(float damage)
    {
        _projectileDamage = damage;
    }
    public float GetDamage()
    {
        return _projectileDamage;
    }

    private IEnumerator ProjectileDeath()
    {
        yield return new WaitForSeconds(7);
        Destroy(gameObject);
    }
}
