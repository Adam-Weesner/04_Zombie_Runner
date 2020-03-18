using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathHandler : MonoBehaviour
{
    private GameObject gameOverCanvas = null;

    private void Start()
    {
        gameOverCanvas = FindObjectOfType<GameOverUI>().gameObject;
        gameOverCanvas.SetActive(false);
    }

    public void OnDeath()
    {
        gameOverCanvas.SetActive(true);
        Time.timeScale = 0;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
}
