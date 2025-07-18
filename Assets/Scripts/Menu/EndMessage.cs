using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EndMessage : MonoBehaviour
{
    public CanvasGroup endCanvasGroup;
    public TMP_Text endText;
    public Button nextButton;

    private int currentIndex = 0;

    private string[] endLines = new string[]
    {
        "Félicitations !",
        "Vous avez contribué à aider la planète et les générations futures.",
        "Votre geste compte !",
        "Merci d’avoir joué !"
    };

    void Start()
    {
        endCanvasGroup.alpha = 0;
        endCanvasGroup.interactable = false;
        endCanvasGroup.blocksRaycasts = false;

        nextButton.onClick.RemoveAllListeners();
        nextButton.onClick.AddListener(NextLine);
    }

    public void StartEndSequence()
    {
        endCanvasGroup.alpha = 1;
        endCanvasGroup.interactable = true;
        endCanvasGroup.blocksRaycasts = true;

        currentIndex = 0;
        endText.text = endLines[currentIndex];
    }

    public void NextLine()
    {
        currentIndex++;
        if (currentIndex < endLines.Length)
        {
            endText.text = endLines[currentIndex];
        }
        else
        {
            // Fin affiche scene de credit
            SceneManager.LoadScene("Credit");
        }
    }
}
