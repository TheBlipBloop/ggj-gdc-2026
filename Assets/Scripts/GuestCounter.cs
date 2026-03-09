using UnityEngine;
using TMPro;

public class GuestCounter : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI guestCounterText;
    void OnEnable()
    {
        Events.OnGuestsChanged.AddListener(UpdateGuestCount);
    }

    void OnDisable()
    {
        Events.OnGuestsChanged.RemoveListener(UpdateGuestCount);
    }

    private void UpdateGuestCount(int delta)
    {
        int currentGuestCount = Game.instance.gameState.guests;
        guestCounterText.text = currentGuestCount.ToString();
    }
}
