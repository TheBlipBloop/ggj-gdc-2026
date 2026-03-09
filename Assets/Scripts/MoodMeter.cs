using UnityEngine;

public class MoodMeter : MonoBehaviour
{
    void OnEnable()
    {
        // Events.OnMoodChanged.AddListener(UpdateMood);
    }

    void OnDisable()
    {
        // Events.OnMoodChanged.RemoveListener(UpdateMood);
    }
}
