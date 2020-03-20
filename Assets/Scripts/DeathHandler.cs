using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathHandler : MonoBehaviour
{
    [SerializeField] private GameObject gameOverUI;

    private void Start()
    {
        gameOverUI.SetActive(false);
    }

    public void OnDeath()
    {
        gameOverUI.SetActive(true);
        Time.timeScale = 0;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
}
