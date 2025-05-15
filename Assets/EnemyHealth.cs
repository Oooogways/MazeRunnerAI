using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int health = 100;
    private WaveManager waveManager;

    void Start()
    {
        waveManager = FindFirstObjectByType<WaveManager>(); 
    }

    public void TakeDamage(int amount)
    {
        health -= amount;
        Debug.Log(transform.name + " took " + amount + " damage. Remaining Health: " + health);

        if (health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Debug.Log(transform.name + " died!");

        if (waveManager != null)
        {
            waveManager.EnemyKilled(); 
        }

        Destroy(gameObject);
    }
}
