using UnityEditor.ShaderGraph.Internal;
using UnityEngine;

public class BulletSpawner : MonoBehaviour
{
    public GameObject bulletPrefab;
    public float spawnInterval = 0.75f;
    private float timer = 0.0f;

    private void Start()
    {
        
    }

    // Update is called once per frame
    private void Update()
    {
        if (timer > spawnInterval)
        {
            Instantiate(bulletPrefab, new Vector3(17.0f, Random.Range(-7.5f, 7.5f), 0.0f), Quaternion.identity);
            timer = 0.0f;
        }

        timer += Time.deltaTime;
    }
}
