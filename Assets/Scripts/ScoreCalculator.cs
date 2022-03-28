using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ScoreCalculator : MonoBehaviour
{
    public int score;
    public Text scoreText;
    public GameObject gameOverPanel;
    public Button quit;
    public Button restart;
    public bool IsGameOver=false;
    private void Start()
    {
        quit.onClick.AddListener(Quit);
        restart.onClick.AddListener(Restart);
    }
    public void Score()
    {
        score = score + 5;
        Debug.Log(score);
        scoreText.text = "Score: " + score;
        if(score>50)
        {
            gameOverPanel.SetActive(true);
            IsGameOver = true;
        }

    }
    public void Quit()
    {
        SceneManager.LoadScene(0);
    }
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
