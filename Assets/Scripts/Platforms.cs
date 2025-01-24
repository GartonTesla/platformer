using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platforms : MonoBehaviour
{
    private BoxCollider2D bc;
    public CompositeCollider2D cc;
    private bool IsTrigger;


    private void Awake()
    {
        bc = GetComponent<BoxCollider2D>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            IsTrigger = true;
            cc.isTrigger = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            IsTrigger = false;
            cc.isTrigger = false;
        }
    }
}
