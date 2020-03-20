using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneHandler : Singleton<SceneHandler>
{
    private int currIndex = 0;

    public void NextScene()
    {
        currIndex++;
        SceneManager.LoadScene(currIndex);
        Time.timeScale = 1;
    }

    public void ResetScene()
    {
        SceneManager.LoadScene(currIndex);
        Time.timeScale = 1;
    }
}
