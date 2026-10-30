using System;
using System.Collections;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private ParticleSystem deathParticlePrefab;

    private bool isDamagable = true;

    public float Health
    {
        get; private set;
    }

    private void Start()
    {
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
            OnDeath?.Invoke();
            Destroy(gameObject);
            return;
        }
    }

    static public event Action<float> OnHealthChange;
    static public event Action OnDeath;
    static public event Action OnHeal;
    static public event Action OnHurt;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out IDamager damager))
        {
            if (isDamagable)
            {
                GameObject damagerGameObject = (damager as Component).gameObject;

                Health -= damager.Damage;

                if (Health <= 0.0f)
                {
                    Health = 0.0f;
                }
                else
                {
                    OnHurt?.Invoke();
                }

                Destroy(damagerGameObject);
                OnHealthChange?.Invoke(Health);

                StartCoroutine(IFrames());
            }
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
        BlackHole.DamagePlayer += DamagePlayer;
    }

    private void OnDestroy()
    {
        OnHealthChange = null;
        OnHeal = null;
        OnDeath = null;
        OnHurt = null;
    }

    private void DamagePlayer(float damage)
    {
        if (isDamagable)
        {
            Health -= damage;
            if (Health < 0.0f) Health = 0.0f;
            OnHealthChange?.Invoke(Health);

            StartCoroutine(IFrames());
        }
    }

    private IEnumerator IFrames()
    {
        float timer = 0.0f;
        float IFramesDuration = 0.5f;
        isDamagable = false;

        while (timer < IFramesDuration)
        {
            timer += Time.deltaTime;
            yield return null;
        }

        isDamagable = true;
    }
}
