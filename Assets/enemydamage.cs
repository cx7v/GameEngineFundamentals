using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public float damageAmount = 10f;

    // Detect when the enemy enters the player's trigger/collider
    private void OnTriggerEnter(Collider other) // Use OnTriggerEnter2D for 2D games
    {
        // Check if the object hit has the "Player" tag
        if (other.CompareTag("Player"))
        {
            // Get the PlayerHealth script attached to the player
            PlayerHealth playerHealth = other.GetComponent<PlayerHealth>();

            if (playerHealth != null)
            {
                // Deal damage to the player
                playerHealth.TakeDamage(damageAmount);
            }
        }
    }
}
