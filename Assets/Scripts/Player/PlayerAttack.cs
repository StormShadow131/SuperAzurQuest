using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private GameObject attackAreaL;
    private GameObject attackAreaR;
    private Animator animator;

    private bool attacking = false;
    public bool IsAttacking => attacking;

    private float attackDuration = 1.8f;
    private float attackTimer = 0f;
  
    public string attackingAnimationTrigger = "Attacking";

    private SpriteRenderer spriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        attackAreaL = transform.Find("AttackAreaL").gameObject;
        attackAreaR = transform.Find("AttackAreaR").gameObject;
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();

        attackAreaL.SetActive(false);
        attackAreaR.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && !attacking)
        {
            Attack();
        }

        if (attacking)
        {
            attackTimer += Time.deltaTime;

            if (attackTimer >= attackDuration)
            {
                attackAreaL.SetActive(false);
                attackAreaR.SetActive(false);
                attacking = false;
                attackTimer = 0;
            }

        }
    }

    private void Attack()
    {
        attacking = true;
        attackTimer = 0;

        // Active la bonne zone d'attaque en fonction de la direction
        if (spriteRenderer.flipX)
        {
            // On regarde vers la gauche
            attackAreaL.SetActive(true);
        }
        else
        {
            // On regarde vers la droite
            attackAreaR.SetActive(true);
        }

        // Play the animation
        animator.SetTrigger(attackingAnimationTrigger);
    }
}
