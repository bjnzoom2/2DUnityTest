using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class DeathHandler : MonoBehaviour
{
    [SerializeField] private Volume postProcessing;

    private float slowDownDuration = 2.0f;

    private float _musicPitchScale;
    public float MusicPitchScale
    {
        get => _musicPitchScale;
        private set
        {
            _musicPitchScale = value;
            ChangeAudioPitch?.Invoke(_musicPitchScale);
        }
    }

    static public event Action<float> ChangeAudioPitch;
    static public event Action UIGameOver;

    private void OnEnable()
    {
        PlayerHealth.OnDeath += () =>
        {
            StartCoroutine(HandlePlayerDeath());
        };
    }

    private IEnumerator HandlePlayerDeath()
    {
        float timer = 0.0f;
        while (timer < slowDownDuration)
        {
            Time.timeScale = (slowDownDuration - timer) / slowDownDuration;
            timer += Time.unscaledDeltaTime;
            MusicPitchScale = (slowDownDuration - timer) / slowDownDuration;

            postProcessing.profile.TryGet(out ColorAdjustments colorAdjustments);
            colorAdjustments.saturation.value = Mathf.Lerp(-100.0f, 0.0f, (slowDownDuration - timer) / slowDownDuration);

            yield return null;
        }

        yield return new WaitForSecondsRealtime(0.5f);
        UIGameOver?.Invoke();
    }

    private void OnDestroy()
    {
        ChangeAudioPitch = null;
        UIGameOver = null;
    }
}
