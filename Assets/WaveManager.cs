using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class WaveManager : MonoBehaviour
{
    public GameObject enemyPrefab;  
    public Transform[] spawnPoints; 
    public Text waveText;            
    private int waveNumber = 1;
    private int enemiesAlive = 0;

    void Start()
    {
        Debug.Log("WaveManager Started.");
        StartCoroutine(StartWave());
    }

    IEnumerator StartWave()
    {
        Debug.Log("Starting Wave " + waveNumber);
        waveText.text = "Level " + waveNumber;

        enemiesAlive = waveNumber; 

        for (int i = 0; i < enemiesAlive; i++)
        {
            Transform spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];
            GameObject enemy = Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);

            
            EnemyAI ai = enemy.GetComponent<EnemyAI>();
            if (ai != null)
            {
                GameObject playerObject = GameObject.FindGameObjectWithTag("Player");
                if (playerObject != null)
                {
                    ai.player = playerObject.transform;
                }
            }

            yield return new WaitForSeconds(0.5f); 
        }
    }

    public void EnemyKilled()
    {
        enemiesAlive--;

        if (enemiesAlive <= 0)
        {
            waveNumber++;
            StartCoroutine(StartWave());
        }
    }
}
