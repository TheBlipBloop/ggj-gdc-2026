using UnityEngine;
using TMPro;

public class GameOverPopup : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private GameObject screen;

    public void ShowPopup()
    {
        scoreText.text = $"{Game.instance.gameState.sacrifices} Kills";
        screen.SetActive(true);
    }

    public void RestartGame()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(0);
    }
}
