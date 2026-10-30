using System;
using UnityEngine;

public class RadiationWaveSpawner : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] private GameObject radiationWavePrefab;

    private float timer = 0.0f;
    [NonSerialized] static public float spawnInterval = 0.6f;

    // Update is called once per frame
    private void Update()
    {
        if (!LogicHandler.RadiationActive)
        {
            timer = 0.0f;
            return;
        }
        if (timer >= spawnInterval)
        {
            GameObject radiationInstance = Instantiate(radiationWavePrefab, new Vector3(UnityEngine.Random.Range(-15.0f, 15.0f), 8.0f, 0.0f), Quaternion.identity);
            timer = 0.0f;
        }

        timer += Time.deltaTime;
    }
}
