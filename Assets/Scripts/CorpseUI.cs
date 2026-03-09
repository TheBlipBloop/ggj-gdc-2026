using UnityEngine;
using TMPro;

public class CorpseUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI corpseCounterText;

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
    }
}
