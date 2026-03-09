using System.Collections.Generic;
using UnityEngine;

public class PhaseUI : MonoBehaviour
{
    [SerializeField] private Transform wheel;

    private Dictionary<GamePhase, float> phaseRotations = new Dictionary<GamePhase, float>
    {
        { GamePhase.Prep, 110f },
        { GamePhase.Party, 239f },
        { GamePhase.Slaughter, 359f }
    };

    void OnEnable()
    {
        Events.OnPhaseStarted.AddListener(OnPhaseStarted);
    }

    void OnDisable()
    {
        Events.OnPhaseStarted.RemoveListener(OnPhaseStarted);
    }

    private void OnPhaseStarted(GamePhase phase)
    {
        if (phaseRotations.TryGetValue(phase, out float targetRotation))
        {
            wheel.localRotation = Quaternion.Euler(0f, 0f, targetRotation);
        }
    }


}
