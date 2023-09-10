using UnityEngine;
using UnityEngine.SceneManagement;


public class SceneController : MonoBehaviour
{
    int highScore = 0;
    // This method loads a new scene
    public GameMenu gameMenu;

    public void StartGame()
    {

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
        gameMenu.ContinueGame();
    }
    //public void highScore()
    //{

    //}
    //private void Update()
    //{
    //    if (gameMenu != null)
    //    {
    //        gameMenu.ContinueGame();
    //    }
    //}
    public void QuitGame()
    {
        Application.Quit();

    }
   public void UpdateHighScore(int score)
    {
        if (score > highScore)
        {
            highScore = score;
        }
    }
    //PlayerPrefs.SetInt("HighScore", highScore);
    //    int highScore = PlayerPrefs.GetInt("HighScore");

}