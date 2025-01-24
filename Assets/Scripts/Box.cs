using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour
{
    private int value = 10;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            PubSub.Publish(new BoxTakeEvent() { Value = value });
            PubSub.Publish(new GetHPEvent() { NewHP = value });
            Destroy(gameObject);
        }
    }
}
