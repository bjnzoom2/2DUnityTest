using System;
using System.ComponentModel;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public float bulletSpeed = 8.0f;
    [ReadOnly(true)] public float bulletDirection;

    private void Start()
    {
        
    }

    // Update is called once per frame
    private void Update()
    {
        transform.position += new Vector3(bulletDirection, 0.0f, 0.0f) * bulletSpeed * Time.deltaTime;
        transform.Rotate(0.0f, 0.0f, 45.0f * Time.deltaTime);

        if (transform.position.x > 25.0f || transform.position.x < -25.0f)
        {
            Destroy(gameObject);
            return;
        }
    }
}
