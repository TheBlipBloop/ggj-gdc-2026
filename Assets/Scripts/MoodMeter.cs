using UnityEngine;

public class MoodMeter : MonoBehaviour
{
    [SerializeField] Transform lightbulbParent;
    [SerializeField] MoodLightbulb lightbulbPrefab;
    [SerializeField] Transform labelParent;
    [SerializeField] MoodLabel labelPrefab;

    void Start()
    {
        BuildMoodBar(Game.instance.moodThresholds);
        UpdateMood(0);
    }

    void OnEnable()
    {
        Events.OnMoodChanged.AddListener(UpdateMood);
    }

    void OnDisable()
    {
        Events.OnMoodChanged.RemoveListener(UpdateMood);
    }

    private void UpdateMood(int moodValue)
    {
        SetMoodValue(Game.instance.gameState.mood);
    }

    public void SetMoodValue(int moodValue)
    {
        foreach(MoodLightbulb lightbulb in lightbulbParent.GetComponentsInChildren<MoodLightbulb>())
        {
            lightbulb.Lit = lightbulb.moodValue <= moodValue;
        }
    }

    private void ClearMoodBar()
    {
        foreach(Transform child in lightbulbParent)
        {
            Destroy(child.gameObject);
        }
        foreach(Transform child in labelParent)
        {
            Destroy(child.gameObject);
        }
    }

    private void BuildMoodBar(MoodThresholds moodThresholds)
    {
        ClearMoodBar();

        int prevThreshold = moodThresholds.thresholds[0].threshold;

        for(int i = 1; i < moodThresholds.thresholds.Length; i++)
        {
            int threshold = moodThresholds.thresholds[i].threshold;
            int guestDelta = moodThresholds.thresholds[i].guestDelta;
            int span = threshold - prevThreshold;
            prevThreshold = threshold;

            for(int j=0; j < span; j++)
            {
                MoodLightbulb lightbulb = Instantiate(lightbulbPrefab, lightbulbParent);
                lightbulb.moodValue = threshold - span + j + 1;
            }

            MoodLabel label = Instantiate(labelPrefab, labelParent);
            label.SetLabel(guestDelta, span);
        }
    }
}
