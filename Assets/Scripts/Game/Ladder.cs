using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Ladder : MonoBehaviour
{
    private bool isInRange;
    private PlayerMovement playerMovement;

    public TMP_Text interactTutoUI;

    void Awake()
    {
        playerMovement = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
        interactTutoUI = GameObject.FindGameObjectWithTag("InteractTutoUI").GetComponent<TMP_Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isInRange && playerMovement.isClimbing && Input.GetKeyDown(KeyCode.E))
        {
            // Descendre de l'echelle
            playerMovement.isClimbing = false;
            return;

        }

        if (isInRange && Input.GetKeyDown(KeyCode.E))
        { 
            playerMovement.isClimbing = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isInRange = true;
            interactTutoUI.enabled = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isInRange = false;
            playerMovement.isClimbing = false;
            interactTutoUI.enabled = false;
        }
    }
}
