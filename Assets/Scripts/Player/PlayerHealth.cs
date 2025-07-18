using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;

    public float invincibilityTimeAfterHit = 3f;
    public float invincibilityFlashDelay = 0.2f;
    public bool isInvincible = false;

    public SpriteRenderer graphics;
    public HealthBar healthBar;

    public static PlayerHealth instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("Il y a plus d'une instance de PlayerHealth dans la scène");
            return;
        }

        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    public void HealPlayer(int amount)
    {
        if ((currentHealth + amount) > maxHealth)
        {
            currentHealth = maxHealth;
        }
        else
        {
            currentHealth += amount;
        }

        healthBar.SetHealth(currentHealth);
    }

    public void TakeDamage(int damage)
    {
        if (!isInvincible) 
        {
            currentHealth -= damage;
            healthBar.SetHealth(currentHealth);

            // Check if the player is still alive
            if (currentHealth <= 0)
            {
                Die();
                return;
            }

            isInvincible=true;
            StartCoroutine(InvincibilityFlash());
            StartCoroutine(HandleInvincibilityDelay());
        }
    }

    public void Die()
    {
        // Disable movements
        PlayerMovement.instance.enabled = false;

        // Play the animation
        PlayerMovement.instance.animator.SetTrigger("Death");

        // Disable physical interactions
        PlayerMovement.instance.rb.bodyType = RigidbodyType2D.Kinematic;
        PlayerMovement.instance.playerCollider.enabled = false;

        GameOverManager.instance.OnPlayerDeath();
    }

    public IEnumerator InvincibilityFlash()
    {
        while (isInvincible)
        {
            graphics.color = new Color(1f, 1f, 1f, 0f);
            yield return new WaitForSeconds(invincibilityFlashDelay);
            graphics.color = new Color(1f, 1f, 1f, 1f);
            yield return new WaitForSeconds(invincibilityFlashDelay);
        }
    }

    public IEnumerator HandleInvincibilityDelay()
    {
        yield return new WaitForSeconds(invincibilityTimeAfterHit);
        isInvincible = false;
    }
}
