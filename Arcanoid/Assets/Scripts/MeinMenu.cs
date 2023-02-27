using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MeinMenu : MonoBehaviour
{
    public void Level1()
    {
        SceneManager.LoadScene("Level1");
    }

    public void Level2()
    {
        SceneManager.LoadScene("Level2");
    }

    public void Level_Infinite()
    {
        SceneManager.LoadScene("Level3_Infinite");
    }

    public void Exit()
    {
        Application.Quit();
    }
}
