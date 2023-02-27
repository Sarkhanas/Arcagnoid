using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int lives = 3;
    public GameObject prefab;

    public List<Brick> brickMap;
    public List<Vector2> positions;

    private void Start()
    {
        FindObjectOfType<Counter>().ChangeHealth(lives);

        for (int i = 0; i < brickMap.Count; i++)
        {
            positions.Add(brickMap[i].transform.position);
        }
    }

    public void LosseHealth()
    {
        lives--;
        FindObjectOfType<Counter>().ChangeHealth(lives);

        if (lives <= 0)
        {
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
        Color[] colors = new Color[] { new Color(102, 56, 104), new Color(206, 88, 19), new Color(231, 198, 71), new Color(23, 129, 94) , new Color(22, 71, 90) };

        ResetLevel();
        brickMap = new List<Brick>();

        for (int i = 0; i < positions.Count; i++)
        {
            GameObject obj = Instantiate(prefab, positions[i], Quaternion.identity, gameObject.transform);
            obj.GetComponent<SpriteRenderer>().color = colors[Random.Range(0, colors.Length)];
        }
    }
}
