using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
<<<<<<< HEAD
    public Transform player;
    private NavMeshAgent agent;

    public float chaseDistance = 10f;
    public int health = 100;
    public float moveSpeed = 3.5f;
    public int damage = 10;

    public WaveManager waveManager;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.speed = moveSpeed;
=======
    // Reference to the player's Transform.
    public Transform player;

    // The distance within which the enemy will start chasing the player.
    public float chaseDistance = 8f;

    // Array of patrol points for the enemy's patrol route.
    public Transform[] patrolPoints;

    // How long the enemy waits at each patrol point before moving to the next.
    public float waitTimeAtPatrolPoint = 2f;

    // Reference to the NavMeshAgent component on the enemy.
    private NavMeshAgent agent;

    // Index of the current patrol point.
    private int currentPatrolIndex = 0;

    // Timer to handle waiting at patrol points.
    private float waitTimer = 0f;

    // Flag to indicate whether the player is detected.
    public bool isPlayerDetected = false;

    void Start()
    {
        // Get the NavMeshAgent component from this GameObject.
        agent = GetComponent<NavMeshAgent>();

        // If there are patrol points, start patrolling.
        if (patrolPoints.Length > 0)
        {
            agent.SetDestination(patrolPoints[currentPatrolIndex].position);
        }
>>>>>>> b15ae4d7a7033609add3b6fa805f50e4913641f5
    }

    void Update()
    {
<<<<<<< HEAD
        if (player != null)
        {
            float distance = Vector3.Distance(transform.position, player.position);
            if (distance < chaseDistance)
            {
=======
        // Ensure that we have a reference to the player.
        if (player != null)
        {
            // Calculate the distance to the player.
            float distanceToPlayer = Vector3.Distance(transform.position, player.position);

            // If the player is within chase distance, start chasing.
            if (distanceToPlayer < chaseDistance)
            {
                isPlayerDetected = true;
>>>>>>> b15ae4d7a7033609add3b6fa805f50e4913641f5
                agent.SetDestination(player.position);
            }
            else
            {
<<<<<<< HEAD
                agent.ResetPath();
=======
                isPlayerDetected = false;
                Patrol();
>>>>>>> b15ae4d7a7033609add3b6fa805f50e4913641f5
            }
        }
    }

<<<<<<< HEAD
    public void TakeDamage(int amount)
    {
        health -= amount;
        if (health <= 0)
        {
            if (waveManager != null)
            {
                waveManager.EnemyKilled();
            }

            Destroy(gameObject);
=======
    // Method to handle patrolling between points.
    void Patrol()
    {
        // If no patrol points are set, do nothing.
        if (patrolPoints.Length == 0)
            return;

        // Check if the agent has reached its destination.
        if (!agent.pathPending && agent.remainingDistance < 0.5f)
        {
            // Increment the timer.
            waitTimer += Time.deltaTime;

            // When wait time is exceeded, switch to the next patrol point.
            if (waitTimer >= waitTimeAtPatrolPoint)
            {
                waitTimer = 0f;
                currentPatrolIndex = (currentPatrolIndex + 1) % patrolPoints.Length;
                agent.SetDestination(patrolPoints[currentPatrolIndex].position);
            }
>>>>>>> b15ae4d7a7033609add3b6fa805f50e4913641f5
        }
    }
}
