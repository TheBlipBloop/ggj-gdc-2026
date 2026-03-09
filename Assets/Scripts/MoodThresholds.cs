using UnityEngine;

[System.Serializable]
public class MoodThreshold
{
    public int threshold;
    public int guestDelta;
}

[CreateAssetMenu(fileName = "MoodThresholds", menuName = "Scriptable Objects/MoodThresholds")]
public class MoodThresholds : ScriptableObject
{
    public MoodThreshold[] thresholds;

    public int GetGuestDelta(int mood)
    {
        int guestDelta = thresholds[0].guestDelta;
        
        foreach (var moodThreshold in thresholds)
        {
            if (mood >= moodThreshold.threshold)
            {
                guestDelta = moodThreshold.guestDelta;
            }
            else
            {
                break;
            }
        }
        return guestDelta;
    }
}
