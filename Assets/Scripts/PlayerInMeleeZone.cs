using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInMeleeZone : MonoBehaviour
{
    private Vector2 playerMeleePos;
    private bool playerInMeleeZone;
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            playerMeleePos = collision.transform.position;
            playerInMeleeZone = true;
        }
        else
        {
            playerInMeleeZone = false;
        }
    }

    public Vector2 CheckPosition()
    {
        return playerMeleePos;
    }
    public bool CheckPlayerInMeleeZone()
    {
        return playerInMeleeZone;
    }

}
