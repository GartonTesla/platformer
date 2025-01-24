using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInZone : MonoBehaviour
{
    private Vector2 playerPos;
    private bool playerInZone;

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

    public Vector2 CheckPosition()
    {
        return playerPos;
    }

    public bool CheckPlayerInZone()
    {
        return playerInZone;
    }
}
