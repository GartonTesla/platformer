using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellCast : MonoBehaviour
{
    private BoxCollider2D bc;
    [SerializeField] private int damage;

    public void Awake()
    {
        bc = GetComponent<BoxCollider2D>();
    }

    public void TriggerOn()
    {
        bc.enabled = true;
    }

    public void TriggerOff()
    {
        bc.enabled = false;
    }

    public void Disable()
    {
        gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            PubSub.Publish(new SpikeCollEvent() { Damage = damage });
        }
    }
}