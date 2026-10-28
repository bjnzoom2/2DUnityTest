using System;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    private BoxCollider2D collider;
    [SerializeField] private ParticleSystem deathParticlePrefab;

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
            OnDeath?.Invoke();
            Destroy(gameObject);
            return;
        }
    }

    static public event Action<float> OnHealthChange;
    static public event Action OnDeath;
    static public event Action OnHeal;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out IDamager damager))
        {
            GameObject damagerGameObject = (damager as Component).gameObject;

            Health -= damager.Damage;
            if (Health < 0.0f) Health = 0.0f;
            Destroy(damagerGameObject);
            OnHealthChange?.Invoke(Health);
        } else if (collision.gameObject.TryGetComponent(out IHealer healer))
        {
            GameObject healerGameObject = (healer as Component).gameObject;

            Health += healer.HealAmount;
            if (Health > 100.0f) Health = 100.0f;
            Destroy(healerGameObject);
            OnHealthChange?.Invoke(Health);
            OnHeal?.Invoke();
        }
    }

    private void OnEnable()
    {
        BlackHole.DamagePlayer += damagePlayer;
    }

    private void damagePlayer(float damage)
    {
        Health -= damage;
        if (Health < 0.0f) Health = 0.0f;
        OnHealthChange?.Invoke(Health);
    }
}
