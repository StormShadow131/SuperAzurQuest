using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public TrashGaugeManager trashGaugeManager;

    private EnemyPatrol enemy;
    private WeakSpot weakSpot;

    public int maxHealth = 10;
    public int currentHealth;

    public string deathAnimationTrigger;

    void Start()
    {
        if (trashGaugeManager == null)
        {
            trashGaugeManager = FindObjectOfType<TrashGaugeManager>();
        }
        currentHealth = maxHealth;

        enemy = GetComponent<EnemyPatrol>();
        weakSpot = GetComponentInChildren<WeakSpot>();
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        // Check if the enemy is still alive
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        if (enemy != null && enemy.animator != null)
        {
            // Play the animation
            enemy.animator.SetTrigger(deathAnimationTrigger);
        }

        if (enemy != null && enemy.enemyCollider != null)
        {
            // Disable physical interactions
            enemy.enemyCollider.enabled = false;
            enemy.enabled = false;
            if (trashGaugeManager != null)
            {
                Debug.Log("JaugeManager trouvé, appel de AddDeadEnemy");
                trashGaugeManager.AddDeadEnemy();
            }
            else
            {
                Debug.LogError("trashGaugeManager est NULL !");
            }
        }

        if (weakSpot != null && weakSpot.weakSpotCollider != null)
        {
            // Disable physical interactions
            weakSpot.weakSpotCollider.enabled = false;
        }
    }
}
