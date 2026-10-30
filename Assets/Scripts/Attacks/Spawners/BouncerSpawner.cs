using System;
using UnityEngine;

public class BouncerSpawner : MonoBehaviour
{
    [SerializeField] private GameObject bouncerPrefab;
    private float timer = 0.0f;
    [NonSerialized] static public float spawnInterval = 5.5f;

    // Update is called once per frame
    private void Update()
    {
        if (!LogicHandler.BouncersActive)
        {
            timer = 0.0f;
            return;
        }

        if (timer >= spawnInterval)
        {
            bool determiner = (UnityEngine.Random.value >= 0.5) ? true : false;
            GameObject bouncerInstance = Instantiate(bouncerPrefab, new Vector3((determiner) ? 16.0f : -16.0f, UnityEngine.Random.Range(-6.0f, 6.0f), 0.0f), Quaternion.Euler(0.0f, 0.0f, (determiner) ? UnityEngine.Random.Range(-230.0f, -130.0f) : UnityEngine.Random.Range(-50.0f, 50.0f)));
            timer = 0.0f;
        }

        timer += Time.deltaTime;
    }
}
