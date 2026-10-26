using System;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    private BoxCollider2D collider;
    [SerializeField] static private ParticleSystem deathParticlePrefab;

    public float Health
    {
        get; private set;
    }

    private void Start()
    {
        collider = GetComponent<BoxCollider2D>();
        Health = 100.0f;
    }

    private void Update()
    {
        if (Health <= 0.0f)
        {
            if (deathParticlePrefab != null)
            {
                ParticleSystem deathParticleInstance = Instantiate(deathParticlePrefab, transform.position, Quaternion.identity);
                deathParticleInstance.Play();
            }
            Debug.Log("Dead");
            Destroy(gameObject);
            return;
        }
    }

    static public event Action<float> OnTakeDamage;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent<IDamager>(out IDamager damager))
        {
            GameObject damagerGameObject = (damager as Component).gameObject;

            Health -= damager.Damage;
            Destroy(damagerGameObject);
            OnTakeDamage?.Invoke(Health);
        }
    }
}
