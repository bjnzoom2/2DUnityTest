using System;
using System.Collections;
using Unity.Mathematics;
using UnityEngine;

public class BulletSpawner : MonoBehaviour
{
    [SerializeField] private GameObject bulletPrefab;
    [NonSerialized] static public float spawnInterval = 0.5f;
    private float timer = 0.0f;

    private void Start()
    {
        
    }

    // Update is called once per frame
    private void Update()
    {
        if (!LogicHandler.BulletsActive) {
            timer = 0.0f;
            return;
        }

        if (timer > spawnInterval)
        {
            float determiner = UnityEngine.Random.value;
            GameObject bulletInstance = Instantiate(bulletPrefab, new Vector3((determiner >= 0.5f) ? 17.0f : -17.0f, UnityEngine.Random.Range(-7.5f, 7.5f), 0.0f), Quaternion.identity);
            bulletInstance.TryGetComponent<Bullet>(out Bullet bulletScript);
            bulletScript.bulletDirection = (determiner >= 0.5f) ? -1.0f : 1.0f;
            timer = 0.0f;
        }

        timer += Time.deltaTime;
    }
}
