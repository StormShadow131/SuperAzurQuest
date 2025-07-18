using UnityEngine;
using UnityEngine.SceneManagement;


public class MainMenu : MonoBehaviour
{
    public IntroStory introStory;
    public GameObject introPanel;

    public GameObject buttonPlay;
    public GameObject buttonSettings;
    public GameObject buttonCredits;
    public GameObject buttonQuit;

    public GameObject settingsWindow;

    // Start game
    public void StartGame()
    {
        buttonPlay.SetActive(false);
        buttonSettings.SetActive(false);
        buttonCredits.SetActive(false);
        buttonQuit.SetActive(false);

        // Load intro
        introStory.StartIntroSequence();
    }

    // Open settings window
    public void GameStettings()
    {
        settingsWindow.SetActive(true);
    }

    // Closed settings window
    public void CloseSettingsWindow() 
    {
        settingsWindow.SetActive(false);
    }

    // Load credit
    public void LoadCredit()
    {
        SceneManager.LoadScene("Credit");
    }

    // Leave application
    public void QuitGame()
    {
        Application.Quit();
    }
}
