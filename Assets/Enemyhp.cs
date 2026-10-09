using UnityEngine;

public class EnemyAtack : MonoBehaviour
{
    public float health = 50f;

    // This method is called by the gun script when it hits this object
    public void TakeDamage(float amount)
    {
        health -= amount;

        // Destroy the object if health is 0 or less
        if (health <= 0f)
        {
            Die();
        }
    }

    // Moved Die() inside the EnemyAtack class so TakeDamage can find it
    public void Die()
    {
        // 1. Tell the GameManager to increase the score
        if (GameManager.Instance != null)
        {
            GameManager.Instance.AddKill();
        }

        // 2. Destroy the enemy GameObject safely
        Destroy(gameObject);
    }
}
