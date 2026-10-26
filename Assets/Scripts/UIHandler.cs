using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIHandler : MonoBehaviour
{
    public Slider healthBar;
    public TextMeshProUGUI healthText;

    private void Start()
    {
        if (healthBar == null && healthText == null) return;
        healthBar.value = 100.0f;
        healthText.text = "100/100";
    }

    // Update is called once per frame
    private void OnEnable()
    {
        PlayerHealth.OnTakeDamage += UpdateUI;
    }

    private void UpdateUI(float health)
    {
        if (healthBar != null && healthText != null)
        {
            if (health < 0.0f) health = 0.0f;
            healthBar.value = health;
            healthText.text = $"{health}/100";
        }
    }
}
