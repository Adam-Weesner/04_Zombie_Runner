using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverUI : MonoBehaviour
{
    [SerializeField] private Button resetButton = null;
    [SerializeField] private Button quitButton = null;

    private void Start()
    {
        resetButton.onClick.AddListener(OnResetButtonPressed);
        quitButton.onClick.AddListener(OnQuitButtonPressed);
    }

    private void OnResetButtonPressed()
    {
        SceneHandler.Instance.ResetScene();
    }

    private void OnQuitButtonPressed()
    {
        Application.Quit();
    }
}
