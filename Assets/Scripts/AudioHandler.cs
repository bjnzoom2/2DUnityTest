using UnityEngine;

public class AudioHandler : MonoBehaviour
{
    private AudioSource audioSource;
    [SerializeField] private AudioClip bombFire;
    [SerializeField] private AudioClip bombExplode;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void OnEnable()
    {
        Bomb.OnFire += BombFire;
        Bomb.OnExplode += BombExplode;
    }

    private void BombFire()
    {
        audioSource.PlayOneShot(bombFire, 0.8f);
    }

    private void BombExplode()
    {
        audioSource.PlayOneShot(bombExplode, 0.8f);
    }
}
