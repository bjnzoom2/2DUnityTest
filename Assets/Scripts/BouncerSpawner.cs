using System;
using UnityEngine;

public class BouncerSpawner : MonoBehaviour
{
    [SerializeField] private GameObject bouncerPrefab;
    private float timer = 0.0f;
    [NonSerialized] static public float spawnInterval = 5.0f;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!LogicHandler.BouncersActive)
        {
            timer = 0.0f;
            return;
        }

        if (timer >= spawnInterval)
        {
            bool determiner = (UnityEngine.Random.value >= 0.5) ? true : false;
            GameObject bouncerInstance = Instantiate(bouncerPrefab, new Vector3((determiner) ? 17.0f : -17.0f, UnityEngine.Random.Range(-7.0f, 7.0f), 0.0f), Quaternion.Euler(0.0f, 0.0f, (determiner) ? UnityEngine.Random.Range(-235.0f, -125.0f) : UnityEngine.Random.Range(-55.0f, 55.0f)));
            timer = 0.0f;
        }

        timer += Time.deltaTime;
    }
}
