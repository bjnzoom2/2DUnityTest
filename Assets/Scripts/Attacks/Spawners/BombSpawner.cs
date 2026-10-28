using System;
using System.Collections;
using UnityEngine;

public class BombSpawner : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] private GameObject bombPrefab;

    [NonSerialized] static public float spawnInterval = 2.5f;
    private float timer = 0.0f;

    private void Start()
    {
        
    }

    // Update is called once per frame
    private void Update()
    {
        if (!LogicHandler.BombsActive)
        {
            timer = 0.0f;
            return;
        }

        if (timer >= spawnInterval)
        {
            bool determiner = (UnityEngine.Random.value >= 0.5) ? true : false;
            GameObject bombInstance = Instantiate(bombPrefab, new Vector3((determiner) ? 17.0f : -17.0f, UnityEngine.Random.Range(-7.5f, 7.5f), 0.0f), Quaternion.Euler(0.0f, 0.0f, UnityEngine.Random.Range(-180.0f, 180.0f)));
            timer = 0.0f;
        }

        timer += Time.deltaTime;
    }
}
