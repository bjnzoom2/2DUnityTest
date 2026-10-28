using System;
using System.Collections.Generic;
using UnityEngine;

public class BlackHole : MonoBehaviour, IDamager
{
    private GameObject player;
    private float suctionMagnitude = 80.0f;
    private float timer = 0.0f;

    public float Damage
    {
        get; private set;
    }

    static public event Action<float> DamagePlayer;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        Damage = 100.0f;
    }

    private void Update()
    {
        if (player != null)
        {
            Vector3 playerPosition = player.transform.position;
            float distance = Vector3.Distance(playerPosition, transform.position);
            Vector3 direction = new Vector3((playerPosition.x - transform.position.x) / distance, (playerPosition.y - transform.position.y) / distance, 0.0f).normalized;
            player.transform.position -= (suctionMagnitude / Mathf.Clamp(distance, 8.5f, 17.5f)) * direction * Time.deltaTime;
        }

        if (timer >= LogicHandler.FinalPhaseTime)
        {
            Destroy(gameObject);
            return;
        }

        timer += Time.deltaTime;
    }

    private void OnEnable()
    {
        BlackHoleDamageParticle.OnDamageParticleHit += handleDamageParticle;
    }

    private void handleDamageParticle(List<ParticleSystem.Particle> particles, ParticleSystem system)
    {
        for (int i = 0; i < particles.Count; i++)
        {
            ParticleSystem.Particle particle = particles[i];
            particle.remainingLifetime = 0.0f;
            particles[i] = particle;
        }

        system.SetTriggerParticles(ParticleSystemTriggerEventType.Enter, particles);
        DamagePlayer?.Invoke(BlackHoleDamageParticle.Damage);
    }
}
