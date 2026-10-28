using System;
using System.ComponentModel;
using UnityEngine;

interface IDamager
{
    public float Damage
    {
        get;
    }
}

public class Bullet : MonoBehaviour, IDamager
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public float bulletSpeed = 8.0f;
    [ReadOnly(true)] public float bulletDirection;

    public float Damage
    {
        get; private set;
    }

    private void Start()
    {
        this.Damage = 20.0f;
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
