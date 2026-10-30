using System;
using System.Collections.Generic;
using UnityEngine;

public class BlackHoleDamageParticle : MonoBehaviour
{
    private ParticleSystem particleSystem;
    private GameObject player;
    static public float Damage
    {
        get; private set;
    }

    static public event Action<List<ParticleSystem.Particle>, ParticleSystem> OnDamageParticleHit;

    private void Awake()
    {
        particleSystem = GetComponent<ParticleSystem>();
    }

    private void Start()
    {
        Damage = 20.0f;

        player = GameObject.FindGameObjectWithTag("Player");
        BoxCollider2D collider = player.GetComponent<BoxCollider2D>();
        particleSystem.trigger.AddCollider(collider);
    }

    private void OnParticleTrigger()
    {
        List<ParticleSystem.Particle> particles = new List<ParticleSystem.Particle>();
        particleSystem.GetTriggerParticles(ParticleSystemTriggerEventType.Enter, particles);
        OnDamageParticleHit?.Invoke(particles, particleSystem);
    }

    private void OnDestroy()
    {
        OnDamageParticleHit = null;
    }
}
