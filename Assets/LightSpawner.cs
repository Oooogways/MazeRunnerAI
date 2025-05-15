using UnityEngine;

public class LightSpawner : MonoBehaviour
{
    public GameObject lightPrefab;
    public int numberOfLights = 10;
    public float mazeWidth = 50f;
    public float mazeHeight = 50f;

    void Start()
    {
        for (int i = 0; i < numberOfLights; i++)
        {
            SpawnRandomLight();
        }
    }

    void SpawnRandomLight()
    {
        Vector3 randomPosition = new Vector3(
            Random.Range(-mazeWidth / 2, mazeWidth / 2),
            3f, // height off ground
            Random.Range(-mazeHeight / 2, mazeHeight / 2)
        );

        Instantiate(lightPrefab, randomPosition, Quaternion.identity);
    }
}
