using UnityEngine;

public class TurnCounterUI : MonoBehaviour
{
    [SerializeField] private TMPro.TextMeshProUGUI turnText;

    public GameObject slaughterPhaseIndicator;

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
        var phase = Game.instance.gameState.phase;

        if (phase == GamePhase.Prep)
        {
            turnText.text = (Game.prepTurns - Game.instance.gameState.turnNumber).ToString();
        }
        if (phase == GamePhase.Party)
        {
            turnText.text = (Game.partyTurns - Game.instance.gameState.turnNumber).ToString();
        }

        if (phase == GamePhase.Slaughter)
        {
            turnText.text = "";
        }
        slaughterPhaseIndicator.SetActive(phase == GamePhase.Slaughter);
    }
}
