using UnityEngine;

public class Zombie : MonoBehaviour
{
    public float health = 100f;

    // This function is called by the bullet or gun script
    public void TakeDamage(float amount)
    {
        health -= amount;
        Debug.Log("Enemy hit! Health remaining: " + health);

        if (health <= 0f)
        {
            Die();
        }
    }

    void Die()
    {
        Destroy(gameObject);
    }
}
