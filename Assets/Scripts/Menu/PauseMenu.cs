using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool gameIsPaused = false;

    public GameObject pauseMenu;

    private void Update()
    {
        // If the Escape key is pressed
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            // If the game is already paused
            if (gameIsPaused)
            {
                // Resume the game
                Resume();
            }
            else 
            {
                // Paused the game
                Paused();
            }
        }
    }

    void Paused()
    {
        // Disable player's movements
        PlayerMovement.instance.enabled = false;

        // Enabled pause menu
        pauseMenu.SetActive(true);

        // Stop time
        Time.timeScale = 0f;

        gameIsPaused = true;

    }

    public void Resume()
    {
        // Enabled player's movements
        PlayerMovement.instance.enabled = true;

        // Disable pause menu
        pauseMenu.SetActive(false);

        // Enabled time
        Time.timeScale = 1f;

        gameIsPaused = false;

    }

    // Return to main menu
    public void LoadMainMenu()
    {
        // Remet le temps à la normale
        Time.timeScale = 1f;

        // Réactive les mouvements du joueur au cas où
        PlayerMovement.instance.enabled = true;

        // On considère que le jeu n'est plus en pause
        gameIsPaused = false;

        // Charge le menu principal
        SceneManager.LoadScene("MainMenu");
    }

    // Leave application
    public void QuitButton()
    {
        Application.Quit();
    }
}
