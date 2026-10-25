using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    private BoxCollider2D collider;
    public ParticleSystem deathParticlePrefab;

    public float health = 100.0f;

    private void Start()
    {
        collider = GetComponent<BoxCollider2D>();
    }

    private void Update()
    {
        if (health <= 0.0f)
        {
            if (deathParticlePrefab != null)
            {
                ParticleSystem deathParticleInstance = Instantiate(deathParticlePrefab, transform.position, Quaternion.identity);
                deathParticleInstance.Play();
            }
            Destroy(gameObject);
            return;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent<IDamager>(out IDamager damager))
        {
            GameObject damagerGameObject = (damager as Component).gameObject;

            Debug.Log($"Hit by {damagerGameObject}");
            health -= damager.Damage;
            Destroy(damagerGameObject);
            Debug.Log(health);
        }
    }
}
