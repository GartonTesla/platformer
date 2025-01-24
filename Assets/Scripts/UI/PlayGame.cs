using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayGame : MonoBehaviour
{
    public GameObject menu;


    private void Awake()
    {
        menu.SetActive(true);
        Time.timeScale = 0f;
    }
    public void StartGame()
    {
        menu.SetActive(false);
        Time.timeScale = 1.0f;
    }
}
