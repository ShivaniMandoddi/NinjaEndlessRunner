using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreCalculator : MonoBehaviour
{
    public int score;
    public void Score()
    {
        score = score + 5;
        Debug.Log(score);
    }
}
