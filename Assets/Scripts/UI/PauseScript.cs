using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseScript : MonoBehaviour
{
    public GameObject menu;
    private bool flag;
    public void StopGame()
    {
        Time.timeScale = 0f;
        menu.SetActive(true);
        flag = true;
    }
    public void StartGame()
    {
        Time.timeScale = 1.5f;
        menu.SetActive(false);
        flag = false;
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (flag)
            {
                StartGame();
            }
            else
            {
                StopGame();
            }
        }
    }
}
