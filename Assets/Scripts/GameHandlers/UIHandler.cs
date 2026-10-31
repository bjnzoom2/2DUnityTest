using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIHandler : MonoBehaviour
{
    [SerializeField] private Slider healthBar;
    [SerializeField] private TextMeshProUGUI healthText;
    [SerializeField] private TextMeshProUGUI startText;

    [SerializeField] private CanvasGroup gameOver;
    [SerializeField] private Button tryAgainButton;
    [SerializeField] private Button returnButton;

    private void Start()
    {
        if (healthBar == null && healthText == null) return;
        healthBar.value = 100.0f;
        healthText.text = "100/100";

        if (gameOver != null)
        {
            gameOver.interactable = false;
            gameOver.alpha = 0.0f;
            tryAgainButton.onClick.AddListener(TryAgainButtonClick);
            returnButton.onClick.AddListener(ReturnButtonClick);
        }
    }

    private void OnEnable()
    {
        LogicHandler.StartGame += StartGame;
        LogicHandler.EndGame += EndGame;

        PlayerHealth.OnHealthChange += UpdateUI;

        DeathHandler.UIGameOver += () =>
        {
            StartCoroutine(GameOver());
        };
    }

    private void UpdateUI(float health)
    {
        if (healthBar != null && healthText != null)
        {
            healthBar.value = health;
            healthText.text = $"{health}/100";
        }
    }

    private void StartGame()
    {
        startText.gameObject.SetActive(false);
    }

    private void EndGame()
    {
        startText.gameObject.SetActive(true);
        startText.rectTransform.anchoredPosition = Vector2.zero;
        startText.text = "You Win";
    }

    private IEnumerator GameOver()
    {
        if (gameOver == null) yield return null;

        float timer = 0.0f;
        while (timer < 1.0f)
        {
            gameOver.alpha = timer;
            timer += Time.unscaledDeltaTime;
            yield return null;
        }

        gameOver.interactable = true;
    }

    private void TryAgainButtonClick()
    {
        SceneManager.LoadScene(1);
    }

    private void ReturnButtonClick()
    {
        SceneManager.LoadScene(0);
    }
}
