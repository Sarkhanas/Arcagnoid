using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int lives = 3;

    public List<Brick> prefs;
    private List<Vector2> positions = new List<Vector2>();

    private void Start()
    {
        if (SceneManager.GetActiveScene().buildIndex == 3)
        {
            FindObjectOfType<Counter>().ChangeHealth(lives);

            for (int i = 0; i < gameObject.transform.childCount; i++)
            {
                positions.Add(gameObject.transform.GetChild(i).transform.position);
            }

            for (int i = 0; i < gameObject.transform.childCount; i++)
            {
                Destroy(gameObject.transform.GetChild(i).gameObject);
            }

            Generate();
        }
        
    }

    public void LosseHealth()
    {
        lives--;
        FindObjectOfType<Counter>().ChangeHealth(lives);

        if (lives <= 0)
        {
            GameOverScene.currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
            SceneManager.LoadScene("GameOver");
        } else
        {
            ResetLevel();
        }
    }

    public void ResetLevel()
    {
        FindObjectOfType<Ball>().ResetBall();
        FindObjectOfType<Player>().ResetPlayer();
    }

    public void CheckLevelCompleted()
    {
        if (SceneManager.GetActiveScene().buildIndex != 3)
        {
            if (transform.childCount <= 1)
                {
                    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
                }
        } else
        {
            if (transform.childCount <= 1)
            {
                Generate();
            }
        }
    }

    public void Generate()
    {
        ResetLevel();

        List<Color> colors = new List<Color>() {
            new Color(102f/255f, 56f / 255f, 104f / 255f),
            new Color(206f / 255f, 88f / 255f, 19f / 255f),
            new Color(231f / 255f, 198f / 255f, 71f / 255f),
            new Color(23f / 255f, 129f / 255f, 94f / 255f),
            new Color(22f / 255f, 71f / 255f, 90f / 255f) };

        for (int i = 0; i < positions.Count; i++)
        {
            Brick brick = prefs[Random.Range(0, prefs.Count)];
            brick.changColor(colors[Random.Range(0, colors.Count)]);
            brick.GetComponent<SpriteRenderer>().color = colors[Random.Range(0, colors.Count)];
            Instantiate(brick, positions[i], Quaternion.identity, gameObject.transform);
        }
    }
}
