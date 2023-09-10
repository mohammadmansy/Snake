using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameMenu : MonoBehaviour
{
    public GameObject menu;

    public void StopGame()
    {
        Time.timeScale = 0;
    }
    public void ContinueGame()
    {
        Time.timeScale = 1;
    }

    private void Update()
    {

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            StopGame();
            if (menu.activeSelf)
            {
                menu.SetActive(false);
                ContinueGame();
            }
            else
            {
                menu.SetActive(true);
            }
        }
    }
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex );
        ContinueGame();
    }
    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }
    public void Continue()
    {
        ContinueGame();
        menu.SetActive(false);

    }
}
