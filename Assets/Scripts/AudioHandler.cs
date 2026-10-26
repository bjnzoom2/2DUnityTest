using Unity.VisualScripting;
using UnityEngine;

public class AudioHandler : MonoBehaviour
{
    private AudioSource audioSource;
    [SerializeField] private AudioClip bombFire;
    [SerializeField] private AudioClip bombExplode;
    [SerializeField] private AudioClip bouncerBounce;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void OnEnable()
    {
        Bomb.OnFire += BombFire;
        Bomb.OnExplode += BombExplode;
        Bouncer.OnBounce += BouncerBounce;
    }

    private void BombFire()
    {
        audioSource.PlayOneShot(bombFire, 0.8f);
    }

    private void BombExplode()
    {
        audioSource.PlayOneShot(bombExplode, 0.8f);
    }

    private void BouncerBounce()
    {
        audioSource.PlayOneShot(bouncerBounce, 0.8f);
    }
}
