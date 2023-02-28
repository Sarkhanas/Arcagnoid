using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverScene : MonoBehaviour
{
    public static int currentSceneIndex;

    public void ResetGame()
    {
        SceneManager.LoadScene(currentSceneIndex);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
