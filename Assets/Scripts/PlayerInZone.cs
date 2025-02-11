using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class PlayerInZone : MonoBehaviour
{
    private Vector2 playerPos;
    private bool playerInZone;
    public Transform FixCameraPos;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            playerPos = collision.transform.position;
            playerInZone = true;
        }
        else
        {
            playerInZone = false;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            playerInZone = true;
            PubSub.Publish(new FixCameraBossEvent() { IsPlayerInArea = playerInZone, FixCameraPos = FixCameraPos });
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            playerInZone = false;
            PubSub.Publish(new FixCameraBossEvent() { IsPlayerInArea = playerInZone });
        }
    }

    public Vector2 CheckPosition()
    {
        return playerPos;
    }

    public bool CheckPlayerInZone()
    {
        return playerInZone;
    }
}
