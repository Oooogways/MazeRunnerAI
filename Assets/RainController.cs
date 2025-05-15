using UnityEngine;

public class RainController : MonoBehaviour
{
    public ParticleSystem rainSystem;
    public float minDelay = 10f;
    public float maxDelay = 30f;

    private bool isRaining = false;

    void Start()
    {
        StartCoroutine(RainCycle());
    }

    System.Collections.IEnumerator RainCycle()
    {
        while (true)
        {
            float waitTime = Random.Range(minDelay, maxDelay);
            yield return new WaitForSeconds(waitTime);

            if (isRaining)
            {
                StopRain();
            }
            else
            {
                StartRain();
            }
        }
    }

    void StartRain()
    {
        rainSystem.Play();
        isRaining = true;
        Debug.Log("Rain started!");
    }

    void StopRain()
    {
        rainSystem.Stop();
        isRaining = false;
        Debug.Log("Rain stopped!");
    }
}
