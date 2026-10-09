using UnityEngine;
using UnityEngine.UI; // Required for UI elements

public class PlayerHealth : MonoBehaviour
{
    public float maxHealth = 100f;
    public float currentHealth;
    public Slider healthSlider; // Drag your UI Slider here in the Inspector

    void Start()
    {
        currentHealth = maxHealth;
        if (healthSlider != null)
        {
            healthSlider.maxValue = maxHealth;
            healthSlider.value = currentHealth;
        }
    }

    // Called by the enemy attack script
    public void TakeDamage(float damageAmount)
    {
        currentHealth -= damageAmount;

        // Prevent health from dropping below zero
        if (currentHealth < 0) currentHealth = 0;

        // Update the slider
        if (healthSlider != null)
        {
            healthSlider.value = currentHealth;
        }

        // Handle death
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Debug.Log("Player has died.");
        // Add your death logic (e.g., game over screen, reload scene)
    }
}
