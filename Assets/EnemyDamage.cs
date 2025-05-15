using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    public int damageAmount = 10;
    public float damageCooldown = 1f;
    private float lastDamageTime;

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (Time.time - lastDamageTime >= damageCooldown)
            {
                Debug.Log("Enemy touched Player!"); // TEST LINE
                SimpleHealthText playerHealth = other.GetComponent<SimpleHealthText>();
                if (playerHealth != null)
                {
                    playerHealth.TakeDamage(damageAmount);
                    lastDamageTime = Time.time;
                }
                else
                {
                    Debug.LogWarning("No SimpleHealthText found on Player!");
                }
            }
        }
    }
}
