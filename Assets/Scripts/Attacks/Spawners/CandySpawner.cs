using System;
using UnityEngine;

public class CandySpawner : MonoBehaviour
{
    [SerializeField] private GameObject candyPrefab;

    private void OnEnable()
    {
        LogicHandler.SpawnCandy += spawnCandy;
    }

    private void spawnCandy()
    {
        Instantiate(candyPrefab, new Vector3(-17.0f, UnityEngine.Random.Range(-6.5f, 6.5f), 0.0f), Quaternion.identity);
    }

    private void OnDisable()
    {
        LogicHandler.SpawnCandy -= spawnCandy;
    }
}
