using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public int score = 0; // public variable to store the score
    public int highScore = 0; // public variable to store the high score
    public Text scoreText; // public reference to the Text object to display the score
    public Text highScoreText;
    // Update the score and display it on the Text object
    void Update()
    {
        scoreText.text = "Score: " + score.ToString();
        highScoreText.text = "High Score: " + highScore.ToString();

        // Update the high score if the current score is greater than the current high score
        if (score > highScore)
        {
            highScore = score;

        }

    }
}