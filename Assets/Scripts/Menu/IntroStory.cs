using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class IntroStory : MonoBehaviour
{
    public GameObject introPanel;
    public TMP_Text storyText;
    public Button nextButton;

    public CanvasGroup introCanvasGroup;

    //public string levelToLoad;

    private int currentIndex = 0;

    // Liste de ton histoire
    private string[] storyLines = new string[]
    {
        "L�animation avec les �co-conseillers du Syndicat Azur �tait int�ressante.",
        "�a m�a donn� envie de ramasser les d�chets dans la rue et de les mettre dans les bon bacs.",
        "Allons-y !"
    };

    void Start()
    {
        introCanvasGroup.alpha = 0;
        introCanvasGroup.interactable = false;
        introCanvasGroup.blocksRaycasts = false;

        nextButton.onClick.AddListener(NextLine);
    }
    public void StartIntroSequence()
    {
        introCanvasGroup.alpha = 1f;
        introCanvasGroup.interactable = true;
        introCanvasGroup.blocksRaycasts = true;

        currentIndex = 0;
        storyText.text = storyLines[currentIndex];    
    }

    void NextLine()
    {
        currentIndex++;
        if (currentIndex < storyLines.Length)
        {
            storyText.text = storyLines[currentIndex];
        }
        else 
        {
            // Si fin de l�intro on lance le jeu
            SceneManager.LoadScene("Level01");
        }
    }
}
