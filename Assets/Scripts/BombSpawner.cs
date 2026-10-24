using UnityEngine;

public class BombSpawner : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public GameObject bombPrefab;

    public float spawnInterval = 2.0f;
    public float timer = 0.0f;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (timer >= spawnInterval)
        {
            bool determiner = (Random.value >= 0.5) ? true : false;
            GameObject bombInstance = Instantiate(bombPrefab, new Vector3((determiner) ? 17.0f : -17.0f, Random.Range(-7.5f, 7.5f), 0.0f), Quaternion.Euler(0.0f, 0.0f, Random.Range(-180.0f, 180.0f)));
            timer = 0.0f;
        }

        timer += Time.deltaTime;
    }
}
