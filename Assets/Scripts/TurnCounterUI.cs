using UnityEngine;

public class TurnCounterUI : MonoBehaviour
{
    [SerializeField] private TMPro.TextMeshProUGUI turnText;

    void OnEnable()
    {
        Events.OnTurnEnded.AddListener(OnTurnEnded);
        Events.OnPhaseStarted.AddListener(OnPhaseStarted);
    }

    void OnDisable()
    {
        Events.OnTurnEnded.RemoveListener(OnTurnEnded);
        Events.OnPhaseStarted.RemoveListener(OnPhaseStarted);
    }

    private void OnPhaseStarted(GamePhase phase)
    {
        UpdateTurnCounter();
    }

    private void OnTurnEnded(int turnNumber)
    {
        UpdateTurnCounter();
    }

    private void UpdateTurnCounter()
    {
        turnText.text = Game.instance.gameState.turnNumber.ToString();
    }
}
