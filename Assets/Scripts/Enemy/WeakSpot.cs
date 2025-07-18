using UnityEngine;

public class WeakSpot : MonoBehaviour
{
    private EnemyPatrol enemy;
    private EnemyHealth enemyHealth;
    public string deathAnimationTrigger;
    public BoxCollider2D weakSpotCollider;

    private void Start()
    {
        enemy = GetComponentInParent<EnemyPatrol>();
        enemyHealth = GetComponentInParent<EnemyHealth>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && enemy != null && enemyHealth != null)
        {
            // Vérifie la vitesse verticale
            Rigidbody2D rb = collision.GetComponent<Rigidbody2D>();
            PlayerAttack playerAttack = collision.GetComponent<PlayerAttack>();

            // Vérifie si le joueur est en attaque
            bool isFallingFast = rb != null && rb.velocity.y < -2f;
            bool isAttacking = playerAttack != null && playerAttack.IsAttacking;

            // Si l'un des deux est vrai on tue l'ennemi
            if (isFallingFast || isAttacking)
            {
                enemyHealth.Die();
            }
        }
    }
}
