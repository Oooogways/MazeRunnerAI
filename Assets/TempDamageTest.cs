using UnityEngine;

public class TempDamageTest : MonoBehaviour
{
<<<<<<< HEAD
    public SimpleHealthText healthSystem;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            healthSystem.TakeDamage(10);
=======
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
>>>>>>> b15ae4d7a7033609add3b6fa805f50e4913641f5
    }
}
