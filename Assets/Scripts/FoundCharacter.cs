using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoundCharacter : MonoBehaviour
{
    private Vector3 playerPosition;


    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            playerPosition = collision.transform.position;
        }
    }
    public Vector3 PlayerPosition()
    {
        return new Vector3(playerPosition.x, -52f, playerPosition.z);
    }
}
