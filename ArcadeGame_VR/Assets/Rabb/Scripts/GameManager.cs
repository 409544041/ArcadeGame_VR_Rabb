using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameManager : MonoBehaviour
{
    public int lives;
    int score;
    [SerializeField]
    private Text livesText;
    [SerializeField]
    private Text scoreText;
    [SerializeField]
    private Text highScoreText;
    // Start is called before the first frame update
    void Start()
    {
        lives = 3;
        score = 0;
        UpdateScoreAndLives();
    }

    private void UpdateScoreAndLives()
    {
        scoreText.text = score.ToString();
        livesText.text = lives.ToString();
        highScoreText.text = score.ToString();
    }

    public void AddScore(int points)    
    {
        score += points;
        UpdateScoreAndLives();
    }

    public void SubtractLives()
    {
        lives--;
        UpdateScoreAndLives();

    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
