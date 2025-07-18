using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerSpawn : MonoBehaviour
{
    private PlayerMovement playerMovement;

    public TMP_Text moveTutoUI;
    public TMP_Text jumpTutoUI;
    public TMP_Text jumpAttackTutoUI;
    public TMP_Text attackTutoUI;

    private bool hasPressedA = false;
    private bool hasPressedD = false;

    private bool hasPressedF = false;

    private void Awake()
    {
        GameObject.FindGameObjectWithTag("Player").transform.position = transform.position;
       
        moveTutoUI = GameObject.FindGameObjectWithTag("MoveTutoUI").GetComponent<TMP_Text>();
        jumpTutoUI = GameObject.FindGameObjectWithTag("JumpTutoUI").GetComponent<TMP_Text>();
        
        jumpAttackTutoUI = GameObject.FindGameObjectWithTag("JumpAttackTutoUI").GetComponent<TMP_Text>();
        attackTutoUI = GameObject.FindGameObjectWithTag("AttackTutoUI").GetComponent<TMP_Text>();
    }

    void Start()
    {
        // Dès qu'on spawn le texte de MoveTutoUI s'active
        moveTutoUI.enabled = true;

        // On desactive le text de JumpTutoUI
        jumpTutoUI.enabled = false;

        // On desactive le text de JumpAttackTutoUI
        jumpAttackTutoUI.enabled = false;

        // On desactive le text de AttackTutoUI
        attackTutoUI.enabled = false;
    }

    void Update()
    {
        // Vérifie si les touches sont pressées
        if (Input.GetKeyDown(KeyCode.A)) hasPressedA = true;
        if (Input.GetKeyDown(KeyCode.D)) hasPressedD = true;

        if (Input.GetKeyDown(KeyCode.F)) hasPressedF = true;

        // Si les deux touches ont été pressées, on desactive le texte
        if (moveTutoUI.enabled && hasPressedA && hasPressedD)
        {
            moveTutoUI.enabled = false;
            moveTutoUI.gameObject.SetActive(false);
        }

        // Ensuit on affiche le texte de JumpTutoUI 
        if (!moveTutoUI.enabled && !jumpTutoUI.enabled && !jumpAttackTutoUI.enabled && !attackTutoUI.enabled)
        {
            jumpTutoUI.enabled = true;
        }

        // Si le joueur appui ESPACE, on desactive le texte
        if (jumpTutoUI.enabled && Input.GetKeyDown(KeyCode.Space))
        {
            jumpTutoUI.gameObject.SetActive(false);
        }



        // Ensuit on affiche le texte de JumpAttckTutoUI 
        if (!moveTutoUI.enabled && !jumpTutoUI.enabled && !jumpAttackTutoUI.enabled && !attackTutoUI.enabled)
        {
            jumpAttackTutoUI.enabled = true;
        }

        // Si le joueur appui ESPACE, on desactive le texte
        if (jumpAttackTutoUI.enabled && Input.GetKeyDown(KeyCode.Space))
        {
            jumpAttackTutoUI.gameObject.SetActive(false);
        }

        // Ensuit on affiche le texte de AttckTutoUI 
        if (!moveTutoUI.enabled && !jumpTutoUI.enabled && !jumpAttackTutoUI.enabled && !attackTutoUI.enabled)
        {
            attackTutoUI.enabled = true;
        }

        // Si le joueur appui F, on desactive le texte
        if (attackTutoUI.enabled && hasPressedF)
        {
            attackTutoUI.gameObject.SetActive(false);
        }
    }
}