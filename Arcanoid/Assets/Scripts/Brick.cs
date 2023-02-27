using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {

            FindObjectOfType<GameManager>().CheckLevelCompleted();

            if (spriteRenderer.color == new Color(102, 56, 104))
            {
                FindObjectOfType<Counter>().IncreasePoint(0);
            } else if (spriteRenderer.color == new Color(206, 88, 19))
            {
                FindObjectOfType<Counter>().IncreasePoint(300);
            } else if (spriteRenderer.color == new Color(231, 198, 71))
            {
                FindObjectOfType<Counter>().IncreasePoint(200);
            }
            else if (spriteRenderer.color == new Color(23, 129, 94))
            {
                FindObjectOfType<Counter>().IncreasePoint(150);
            } else
            {
                FindObjectOfType<Counter>().IncreasePoint(100);
            }

            Destroy(gameObject); 
        }
    }

}
