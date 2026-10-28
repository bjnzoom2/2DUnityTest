using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIHandler : MonoBehaviour
{
    [SerializeField] private Slider healthBar;
    [SerializeField] private TextMeshProUGUI healthText;
    [SerializeField] private TextMeshProUGUI startText;

    private void Start()
    {
        if (healthBar == null && healthText == null) return;
        healthBar.value = 100.0f;
        healthText.text = "100/100";
    }

    private void OnEnable()
    {
        LogicHandler.StartGame += startGame;
        PlayerHealth.OnHealthChange += UpdateUI;
    }

    private void UpdateUI(float health)
    {
        if (healthBar != null && healthText != null)
        {
            healthBar.value = health;
            healthText.text = $"{health}/100";
        }
    }

    private void startGame()
    {
        Destroy(startText.gameObject);
    }
}
