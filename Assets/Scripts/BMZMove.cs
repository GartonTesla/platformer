using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BMZMove : MonoBehaviour
{
    [SerializeField] private GameObject boss;
    private SpriteRenderer sr;



    void Start()
    {
        sr = boss.GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (sr.flipX)
        {
            transform.position = new Vector3(boss.transform.position.x - 2.5f, boss.transform.position.y, boss.transform.position.z);
        }
        else
        {
            transform.position = new Vector3(boss.transform.position.x + 2.5f, boss.transform.position.y, boss.transform.position.z);
        }
    }
}
