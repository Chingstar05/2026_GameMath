using JetBrains.Annotations;
using System.Linq;
using UnityEngine;

public class NewMonoBehaviourScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    { 

    }

    void StanderDeviation()
    {
        
        int n = 10000;
        float[] samples = new float[n];
        for (int i = 0; i < n; i++)
        {
            float mean = samples.Average();
            float sumOfSqures = samples.Sum(x => Mathf.Pow(x - mean, 2));
            float stdDev = Mathf.Sqrt(sumOfSqures / n);

            Debug.Log($"평균: {mean}, 표준편차: {stdDev}");
        }
    }
    float GenerateGaussian(float mean, float stdDev)
    {
        float u1 = 1.0f - Random.value;
        float u2 = 1.0f - Random.value;

        float randStdNormal = Mathf.Sqrt(-2.0f * Mathf.Log(u1)) * Mathf.Sin(2.0f * Mathf.PI * u2);

        return mean + stdDev * randStdNormal;
    }

}
