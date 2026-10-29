using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuHandler : MonoBehaviour
{
    [SerializeField] private Button startButton;

    private void Start()
    {
        startButton.onClick.AddListener(startButtonClicked);
    }

    private void startButtonClicked()
    {
        SceneManager.LoadScene(1);
    }
}
