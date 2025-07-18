using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSpecificScene : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collison)
    {
        if (collison.CompareTag("Player"))
        {
            SceneManager.LoadScene("MainMenu");
        }
    }
}
