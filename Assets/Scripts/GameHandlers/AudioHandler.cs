using UnityEngine;
using UnityEngine.UI;

public class AudioHandler : MonoBehaviour
{
    [SerializeField] private GameObject sfxHandler;
    [SerializeField] private GameObject musicHandler;
    private AudioSource sfxSource;
    private AudioSource musicSource;
    private float masterVolume;
    private bool musicEnabled;
    private bool sfxEnabled;

    [SerializeField] private AudioClip bombFire;
    [SerializeField] private AudioClip bombExplode;
    [SerializeField] private AudioClip bouncerBounce;
    [SerializeField] private AudioClip death;
    [SerializeField] private AudioClip heal;
    [SerializeField] private AudioClip win;
    [SerializeField] private AudioClip hurt;

    [SerializeField] private AudioClip music;

    private void Awake()
    {
        masterVolume = PlayerPrefs.GetFloat("Master Volume");
        musicEnabled = (PlayerPrefs.GetInt("Music On") == 1);
        sfxEnabled = (PlayerPrefs.GetInt("SFX On") == 1);

        sfxSource = sfxHandler.GetComponent<AudioSource>();
        musicSource = musicHandler.GetComponent<AudioSource>();
    }

    private void Start()
    {
        musicSource.volume = 0.5f * (masterVolume / 100.0f);
        musicSource.clip = music;
    }

    private void OnEnable()
    {
        if (musicEnabled)
        {
            LogicHandler.StartGame += PlayMusic;
            LogicHandler.EndGame += Win;
        }

        if (sfxEnabled)
        {
            Bomb.OnFire += BombFire;
            Bomb.OnExplode += BombExplode;
            Bouncer.OnBounce += BouncerBounce;
            PlayerHealth.OnDeath += Death;
            PlayerHealth.OnHeal += Heal;
            PlayerHealth.OnHurt += Hurt;
        }

        DeathHandler.ChangeAudioPitch += AudioPitchAdjust;
    }

    private void BombFire()
    {
        sfxSource.PlayOneShot(bombFire, 1.0f * (masterVolume / 100.0f));
    }

    private void BombExplode()
    {
        sfxSource.PlayOneShot(bombExplode, 1.0f * (masterVolume / 100.0f));
    }

    private void BouncerBounce()
    {
        sfxSource.PlayOneShot(bouncerBounce, 1.2f * (masterVolume / 100.0f));
    }

    private void Death()
    {
        sfxSource.PlayOneShot(death, 1.3f * (masterVolume / 100.0f));
    }

    private void Heal()
    {
        sfxSource.PlayOneShot(heal, 1.0f * (masterVolume / 100.0f));
    }

    private void Hurt()
    {
        sfxSource.PlayOneShot(hurt, 0.7f * (masterVolume / 100.0f));
    }

    private void PlayMusic()
    {
        musicSource.Play();
    }

    private void Win()
    {
        musicSource.Stop();
        sfxSource.PlayOneShot(win, 1.0f * (masterVolume / 100.0f));
    }

    private void AudioPitchAdjust(float pitch)
    {
        musicSource.pitch = pitch;
    }

    private void OnDisable()
    {
        if (musicEnabled)
        {
            LogicHandler.StartGame -= PlayMusic;
            LogicHandler.EndGame -= Win;
        }

        if (sfxEnabled)
        {
            Bomb.OnFire -= BombFire;
            Bomb.OnExplode -= BombExplode;
            Bouncer.OnBounce -= BouncerBounce;
            PlayerHealth.OnDeath -= Death;
            PlayerHealth.OnHeal -= Heal;
            PlayerHealth.OnHurt -= Hurt;
        }

        DeathHandler.ChangeAudioPitch -= AudioPitchAdjust;
    }
}
