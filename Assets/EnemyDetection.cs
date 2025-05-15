using UnityEngine;

public class EnemyDetection : MonoBehaviour
{
<<<<<<< HEAD
    public EnemyAI enemyAI;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            enemyAI.player = other.transform;
=======
    // Reference to the player's Transform
    public Transform player;

    // How far the enemy can detect the player (in world units)
    public float detectionRadius = 10f;

    // The enemy's field-of-view angle in degrees (e.g., 110° means 55° to each side)
    public float fieldOfViewAngle = 110f;

    // LayerMask to ignore obstacles (e.g., walls). Set this in the Inspector.
    public LayerMask obstructionMask;

    // A flag to indicate whether the enemy has detected the player
    public bool isPlayerDetected = false;

    void Update()
    {
        DetectPlayer();
    }

    void DetectPlayer()
    {
        // Calculate the distance from the enemy to the player
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        // Check if the player is within the detection radius
        if (distanceToPlayer < detectionRadius)
        {
            // Calculate the direction vector from the enemy to the player and normalize it
            Vector3 directionToPlayer = (player.position - transform.position).normalized;

            // Calculate the angle between the enemy's forward direction and the direction to the player
            float angle = Vector3.Angle(transform.forward, directionToPlayer);

            // Check if the player is within the enemy's field-of-view
            if (angle < fieldOfViewAngle * 0.5f)
            {
                // Raycast from the enemy's position towards the player to see if any obstacles block the view
                if (!Physics.Raycast(transform.position, directionToPlayer, distanceToPlayer, obstructionMask))
                {
                    // The enemy has a clear line of sight to the player
                    isPlayerDetected = true;
                }
                else
                {
                    // An obstacle is in the way
                    isPlayerDetected = false;
                }
            }
            else
            {
                // The player is outside the enemy's field-of-view
                isPlayerDetected = false;
            }
        }
        else
        {
            // The player is too far away
            isPlayerDetected = false;
>>>>>>> b15ae4d7a7033609add3b6fa805f50e4913641f5
        }
    }
}
