using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuHandler : MonoBehaviour
{
    [SerializeField] private GameObject mainMenu;
    [SerializeField] private GameObject settings;
    [SerializeField] private Button startButton;
    [SerializeField] private Button settingsButton;
    [SerializeField] private Slider masterVolumeSlider;
    [SerializeField] private TextMeshProUGUI masterVolumeText;
    [SerializeField] private Toggle musicToggle;
    [SerializeField] private Toggle sfxToggle;
    [SerializeField] private Button backbutton;

    private void Start()
    {
        startButton.onClick.AddListener(startButtonClicked);
        settingsButton.onClick.AddListener(settingsButtonClicked);
        backbutton.onClick.AddListener(backButtonClicked);
        masterVolumeSlider.onValueChanged.AddListener(masterVolumeSliderChange);
        musicToggle.onValueChanged.AddListener(musicToggleHandler);
        sfxToggle.onValueChanged.AddListener(sfxToggleHandler);

        mainMenu.SetActive(true);
        settings.SetActive(false);

        masterVolumeSliderChange(100.0f);
        musicToggleHandler(true);
        sfxToggleHandler(true);
    }

    private void startButtonClicked()
    {
        PlayerPrefs.Save();
        SceneManager.LoadScene(1);
        Destroy(gameObject);
    }

    private void settingsButtonClicked()
    {
        mainMenu.SetActive(false);
        settings.SetActive(true);
    }

    private void masterVolumeSliderChange(float value)
    {
        masterVolumeText.text = value.ToString();
        PlayerPrefs.SetFloat("Master Volume", value);
    }

    private void musicToggleHandler(bool toggle)
    {
        PlayerPrefs.SetInt("Music On", (toggle) ? 1 : 0);
    }

    private void sfxToggleHandler(bool toggle)
    {
        PlayerPrefs.SetInt("SFX On", (toggle) ? 1 : 0);
    }

    private void backButtonClicked()
    {
        settings.SetActive(false);
        mainMenu.SetActive(true);
    }
}
