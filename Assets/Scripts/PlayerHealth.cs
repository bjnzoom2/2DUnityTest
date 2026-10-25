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
                ParticleSystem deathParticleInstance = Instantiate<ParticleSystem>(deathParticlePrefab, transform.position, Quaternion.identity);
                deathParticleInstance.Play();
            }
            Destroy(gameObject);
            return;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent<Bullet>(out Bullet bullet))
        {
            Debug.Log($"Hit by {bullet.gameObject}");
            health -= 20.0f;
            Destroy(bullet.gameObject);
            Debug.Log(health);
        }
    }
}
