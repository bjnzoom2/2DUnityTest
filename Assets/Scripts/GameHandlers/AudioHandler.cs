using Unity.VisualScripting;
using UnityEngine;

public class AudioHandler : MonoBehaviour
{
    [SerializeField] private GameObject sfxHandler;
    [SerializeField] private GameObject musicHandler;
    private AudioSource sfxSource;
    private AudioSource musicSource;

    [SerializeField] private AudioClip bombFire;
    [SerializeField] private AudioClip bombExplode;
    [SerializeField] private AudioClip bouncerBounce;
    [SerializeField] private AudioClip death;
    [SerializeField] private AudioClip heal;

    [SerializeField] private AudioClip music;

    private void Start()
    {
        sfxSource = sfxHandler.GetComponent<AudioSource>();
        musicSource = musicHandler.GetComponent<AudioSource>();

        musicSource.volume = 0.5f;
        musicSource.clip = music;
    }

    private void OnEnable()
    {
        LogicHandler.StartMusic += PlayMusic;

        Bomb.OnFire += BombFire;
        Bomb.OnExplode += BombExplode;
        Bouncer.OnBounce += BouncerBounce;
        PlayerHealth.OnDeath += Death;
        PlayerHealth.OnHeal += Heal;
    }

    private void BombFire()
    {
        sfxSource.PlayOneShot(bombFire, 1.0f);
    }

    private void BombExplode()
    {
        sfxSource.PlayOneShot(bombExplode, 1.0f);
    }

    private void BouncerBounce()
    {
        sfxSource.PlayOneShot(bouncerBounce, 1.0f);
    }

    private void Death()
    {
        sfxSource.PlayOneShot(death, 1.0f);
    }

    private void Heal()
    {
        sfxSource.PlayOneShot(heal, 1.0f);
    }

    private void PlayMusic()
    {
        musicSource.Play();
    }
}
