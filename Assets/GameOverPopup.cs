using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameOverPopup : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private GameObject screen;
    [SerializeField] private GameObject restartButton;
    [SerializeField] private float rollupInterval = 0.3333f;
    public Image oceanOfBlood;

    public Texture[] backgroundTextures;


    public RawImage background;

    private float killsRollupTimer = 0;

    private int countedKills = 0;
    private float bloodLiters = 0;

    public void ShowPopup()
    {
        countedKills = 0;
        bloodLiters = 0;
        screen.SetActive(true);
        oceanOfBlood.fillAmount = 0;
        restartButton.SetActive(false);
    }

    void Update()
    {
        if (screen.activeSelf == false)
        {
            return;
        }

        killsRollupTimer += Time.deltaTime;
        if (killsRollupTimer > rollupInterval && countedKills < Game.instance.gameState.sacrifices)
        {
            countedKills++;
            killsRollupTimer = 0;

            // average human has 5L of blood.
            // i checked :3
            bloodLiters += Random.Range(4f, 6f);
        }

        if (countedKills == Game.instance.gameState.sacrifices)
        {
            restartButton.SetActive(true);
        }

        scoreText.text = $"{countedKills} Kills\n";
        scoreText.text += $"{bloodLiters:F2}L of Blood";

        float target = Mathf.Clamp01((float)countedKills / 20f);
        oceanOfBlood.fillAmount = Mathf.MoveTowards(oceanOfBlood.fillAmount, target, Time.deltaTime * 0.3f);

        // bad tired 
        Texture bgTexture = backgroundTextures[0];
        if (countedKills > 10)
        {
            bgTexture = backgroundTextures[1];
        }
        if (countedKills > 15)
        {
            bgTexture = backgroundTextures[2];
        }

        background.texture = bgTexture;
    }

    public void RestartGame()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(0);
    }
}
