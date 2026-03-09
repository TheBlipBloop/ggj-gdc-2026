using UnityEngine;
using TMPro;

public class CorpseUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI corpseCounterText;
    [SerializeField] private CanvasGroup canvasGroup;

    void OnEnable()
    {
        Events.OnSacrificesChanged.AddListener(UpdateCorpseCount);
    }

    void OnDisable()
    {
        Events.OnSacrificesChanged.RemoveListener(UpdateCorpseCount);
    }

    private void UpdateCorpseCount(int delta)
    {
        int currentCorpseCount = Game.instance.gameState.sacrifices;
        corpseCounterText.text = currentCorpseCount.ToString();
        canvasGroup.alpha = currentCorpseCount > 0 ? 1f : 0f;
    }
}
