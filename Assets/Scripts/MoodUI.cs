using UnityEngine;
using TMPro;

public class MoodUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI moodText;
    
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
    }
}
