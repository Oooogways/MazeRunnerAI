using UnityEngine;
<<<<<<< HEAD
using UnityEngine.UI;
using UnityEngine.SceneManagement; 

public class SimpleHealthText : MonoBehaviour
{
    public Text healthText;
    public int health = 100;
    public GameObject gameOverPanel;

    private bool isGameOver = false;

    void Start()
    {
        UpdateHealthUI();

        if (gameOverPanel != null)
            gameOverPanel.SetActive(false); 
=======
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
>>>>>>> b15ae4d7a7033609add3b6fa805f50e4913641f5
    }

    void UpdateHealthUI()
    {
<<<<<<< HEAD
        if (healthText != null)
            healthText.text = "Health: " + health;
    }

    public void TakeDamage(int amount)
    {
        if (isGameOver)
            return;

        health -= amount;
        if (health < 0)
            health = 0;

        UpdateHealthUI();

        if (health == 0)
        {
            GameOver();
        }
    }

    private void GameOver()
    {
        isGameOver = true;

        if (gameOverPanel != null)
            gameOverPanel.SetActive(true);

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    
    public void Respawn()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
=======
        // If we assigned the HealthText in the Inspector,
        // this updates the text on screen
        if (healthText != null)
        {
            healthText.text = "Health: " + currentHealth;
        }
    }
>>>>>>> b15ae4d7a7033609add3b6fa805f50e4913641f5
}
