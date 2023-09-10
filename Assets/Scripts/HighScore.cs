using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScore : MonoBehaviour
{
    public int score = 0; // public variable to store the score
    public int highScore = 0; // public variable to store the highest score achieved so far
    public Text scoreText; // public reference to the Text object to display the score
    public Text highScoreText; // public reference to the Text object to display the high score

    // Update the score and display it on the Text object
    void Update()
    {
        scoreText.text = "Score: " + score.ToString();

        if (score > highScore)
        {
            highScore = score;
            highScoreText.text = "High Score: " + highScore.ToString();
        }
    }
}
