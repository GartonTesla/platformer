using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class LootScript : MonoBehaviour
{
    [SerializeField] private List<GameObject> storedItems;
    private CircleCollider2D circleCollider;
    [SerializeField] private Transform spawnPoint;

    private void Start()
    {
        circleCollider = GetComponent<CircleCollider2D>();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        Debug.Log("triggered");
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("playerfound");
            if (Input.GetKey("e"))
            {
                Debug.Log("buttnpressed");
                foreach (GameObject go in storedItems)
                {
                    Instantiate(go, spawnPoint.position, Quaternion.identity);
                }
                //for (int i = 0; i < storedItems.Count; i++)
                //{
                //    Debug.Log("incycle");
                //    Instantiate(storedItems[i], spawnPoint.position, Quaternion.identity);
                //}
                Debug.Log("123");
                Destroy(gameObject);
            }
        }
    }
}
