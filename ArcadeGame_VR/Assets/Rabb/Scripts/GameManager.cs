using UnityEngine;
using UnityEngine.UI;
public class GameManager : MonoBehaviour
{
    public int lives;
    public int score;
    private int highscore;
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
        //score = 0;
        UpdateScoreAndLives();
        UpdateHighScore();
    }

    private void UpdateScoreAndLives()
    {
        scoreText.text = score.ToString();
        livesText.text = lives.ToString();



    }

    public void AddScore(int points)
    {
        score += points;
        UpdateScoreAndLives();

        if (score > PlayerPrefs.GetInt("HighScore", 0))
        {
            PlayerPrefs.SetInt("HighScore", score);

            highScoreText.text = score.ToString();
        }

    }

    public void SubtractLives()
    {
        lives--;
        UpdateScoreAndLives();

    }
    // Update is called once per frame

    void UpdateHighScore()
    {
        highScoreText.text = PlayerPrefs.GetInt("HighScore", 0).ToString();
    }

    public void UpdateLivesAndScore()
    {
        lives = 3;
        score = 0;
        UpdateScoreAndLives();
    }

}
