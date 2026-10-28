using Unity.VisualScripting;
using UnityEngine;

public class AudioHandler : MonoBehaviour
{
    private AudioSource audioSource;
    [SerializeField] private AudioClip bombFire;
    [SerializeField] private AudioClip bombExplode;
    [SerializeField] private AudioClip bouncerBounce;
    [SerializeField] private AudioClip death;
    [SerializeField] private AudioClip heal;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void OnEnable()
    {
        Bomb.OnFire += BombFire;
        Bomb.OnExplode += BombExplode;
        Bouncer.OnBounce += BouncerBounce;
        PlayerHealth.OnDeath += Death;
        PlayerHealth.OnHeal += Heal;
    }

    private void BombFire()
    {
        audioSource.PlayOneShot(bombFire, 0.5f);
    }

    private void BombExplode()
    {
        audioSource.PlayOneShot(bombExplode, 0.5f);
    }

    private void BouncerBounce()
    {
        audioSource.PlayOneShot(bouncerBounce, 0.5f);
    }

    private void Death()
    {
        audioSource.PlayOneShot(death, 1.0f);
    }

    private void Heal()
    {
        audioSource.PlayOneShot(heal, 1.0f);
    }
}
