using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;
    public AudioSource audioSource;
    [SerializeField] protected SoundMappings soundMappings;

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(gameObject);
    }

    void OnEnable()
    {
        Events.OnCardDiscarded.AddListener((Card card) => PlaySound(SoundEvent.CardDiscarded));
        Events.OnCardDrawn.AddListener((Card card) => PlaySound(SoundEvent.CardDrawn));
        Events.OnCardPlayed.AddListener((Card card) => PlaySound(SoundEvent.CardPlayed));
        Events.OnTurnEnded.AddListener((int turn) => PlaySound(SoundEvent.TurnEnded));
        Events.OnPhaseEnded.AddListener((GamePhase phase) => PlaySound(SoundEvent.PhaseEnded));
        Events.OnPhaseStarted.AddListener((GamePhase phase) => PlaySound(SoundEvent.PhaseStarted));
        Events.OnMoodChanged.AddListener((int delta) => PlaySound(delta > 0 ? SoundEvent.MoodGained : SoundEvent.MoodLost));
        Events.OnGuestsChanged.AddListener((int delta) => PlaySound(delta > 0 ? SoundEvent.GuestJoined : SoundEvent.GuestLeft));
        Events.OnSacrificesChanged.AddListener((int delta) => PlaySound(delta > 0 ? SoundEvent.GuestRevived : SoundEvent.GuestMurdered));
    }

    void OnDisable()
    {
        Events.OnCardDiscarded.RemoveListener((Card card) => PlaySound(SoundEvent.CardDiscarded));
        Events.OnCardDrawn.RemoveListener((Card card) => PlaySound(SoundEvent.CardDrawn));
        Events.OnCardPlayed.RemoveListener((Card card) => PlaySound(SoundEvent.CardPlayed));
        Events.OnTurnEnded.RemoveListener((int turn) => PlaySound(SoundEvent.TurnEnded));
        Events.OnPhaseEnded.RemoveListener((GamePhase phase) => PlaySound(SoundEvent.PhaseEnded));
        Events.OnPhaseStarted.RemoveListener((GamePhase phase) => PlaySound(SoundEvent.PhaseStarted));
        Events.OnMoodChanged.RemoveListener((int delta) => PlaySound(delta > 0 ? SoundEvent.MoodGained : SoundEvent.MoodLost));
        Events.OnGuestsChanged.RemoveListener((int delta) => PlaySound(delta > 0 ? SoundEvent.GuestJoined : SoundEvent.GuestLeft));
        Events.OnSacrificesChanged.RemoveListener((int delta) => PlaySound(delta > 0 ? SoundEvent.GuestRevived : SoundEvent.GuestMurdered));
    }

    public void PlaySound(AudioClip clip)
    {
        if (audioSource != null && clip != null)
        {
            audioSource.PlayOneShot(clip);
        }
    }

    public void PlaySound(SoundEvent soundEvent)
    {
        if (soundMappings != null)
        {
            foreach (var mapping in soundMappings.mappings)
            {
                if (mapping.eventName == soundEvent)
                {
                    PlaySound(mapping.clip);
                    break;
                }
            }
        }
    }
}
