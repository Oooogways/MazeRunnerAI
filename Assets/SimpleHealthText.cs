using UnityEngine;
using UnityEngine.UI;  // Required for using UI elements

public class SimpleHealthText : MonoBehaviour
{
    public float maxHealth = 100f;
    public float currentHealth;
    public Text healthText;   // We'll assign our HealthText UI element

    void Start()
    {
        currentHealth = maxHealth;
        UpdateHealthUI();
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
        UpdateHealthUI();
    }

    void UpdateHealthUI()
    {
        // If we assigned the HealthText in the Inspector,
        // this updates the text on screen
        if (healthText != null)
        {
            healthText.text = "Health: " + currentHealth;
        }
    }
}
