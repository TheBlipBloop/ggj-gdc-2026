using UnityEngine;
using TMPro;

public class MoodUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI moodText;
    [SerializeField] private TextMeshProUGUI guestDeltaText;
    
    void OnEnable()
    {
        Events.OnMoodChanged.AddListener(UpdateMood);
    }

    void OnDisable()
    {
        Events.OnMoodChanged.RemoveListener(UpdateMood);
    }

    private void UpdateMood(int delta)
    {
        int currentMood = Game.instance.gameState.mood;
        moodText.text = currentMood.ToString();

        int guestDelta = Game.instance.GuestDelta;
        guestDeltaText.text = (guestDelta >= 0 ? "+" : "") + guestDelta.ToString();
    }
}
