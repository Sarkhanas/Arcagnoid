using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Counter : MonoBehaviour
{
    public Text counter;
    public Text HP;

    private int points = 0;

    public void IncreasePoint(int inc)
    {
        points += inc;
        counter.text = "Points: " + points;
    }

    public void ChangeHealth(int inc)
    {
        HP.text = "HP: " + inc.ToString();
    }
}
