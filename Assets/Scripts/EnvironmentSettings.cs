using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnvironmentSettings : MonoBehaviour
{
    [SerializeField] private GameObject pauseCanvas;
    private void Awake()
    {
        Time.timeScale = 1.5f;
        pauseCanvas.SetActive(true);
    }
}
