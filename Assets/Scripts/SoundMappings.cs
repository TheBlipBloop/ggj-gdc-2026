using UnityEngine;

public enum SoundEvent
{
    MoodGained,
    MoodLost,
    GuestJoined,
    GuestLeft,
    GuestMurdered,
    GuestRevived,
    CardDrawn,
    CardPlayed,
    CardDiscarded,
    TurnEnded,
    PhaseEnded,
    PhaseStarted
}

[System.Serializable]
public class SoundMapping
{
    public SoundEvent eventName;
    public AudioClip clip;
}

[CreateAssetMenu(fileName = "SoundMappings", menuName = "Scriptable Objects/SoundMappings")]
public class SoundMappings : ScriptableObject
{
    public SoundMapping[] mappings;
}
