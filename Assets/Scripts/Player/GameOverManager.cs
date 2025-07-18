using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{

    public GameObject gameOverUI;


    public static GameOverManager instance;

    private void Awake()
    {
        // If an instance already exists
        if (instance != null)
        {
            // Displays a warning in the console
            Debug.LogWarning("Il y a plus d'une instance de GameOverManager dans la scène");
            // Stop execution 
            return;
        }
        // Else, define the instance
        instance = this;
    }

    public void OnPlayerDeath()
    {
        // Enable game over UI
        gameOverUI.SetActive(true);
    }

    // Restart level
    public void RetryButton()
    {
        // Relaod the scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

        // Replace the player on the spawn


        // Enabled player's movements + give him back his life
        gameOverUI.SetActive(false);

    }

    // Return to main menu
    public void MainMenuButton()
    {
        SceneManager.LoadScene("MainMenu");
    }

    // Leave application
    public void QuitButton()
    {
        Application.Quit();
    }
}
