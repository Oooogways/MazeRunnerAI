using UnityEngine;

public class TempDamageTest : MonoBehaviour
{
    public float damageAmount = 10f;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // Attempt to call TakeDamage on the same GameObject
            SimpleHealthText sht = GetComponent<SimpleHealthText>();
            if (sht != null)
            {
                sht.TakeDamage(damageAmount);
                Debug.Log("Damage applied: " + damageAmount + ", Current Health: " + sht.currentHealth);
            }
        }
    }
}
