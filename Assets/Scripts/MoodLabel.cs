using UnityEngine;
using UnityEngine.UI;

public class MoodLabel : MonoBehaviour
{
    [SerializeField] private TMPro.TextMeshProUGUI label;

    [SerializeField] protected Image background;

    private int _mood = 0;

    public void Start()
    {
        Events.OnMoodChanged.AddListener(OnMoodChanged);
        OnMoodChanged(0);
    }

    void OnMoodChanged(int delta)
    {
        if (Game.instance.GuestDelta == _mood)
        {
            background.color = Color.white;
        }
        else
        {
            background.color = new Color(0.7f, 0.7f, 0.7f, 1f);
        }
    }

    public void SetLabel(int moodValue, int span)
    {
        label.text = (moodValue >= 0 ? "+" : "") + moodValue.ToString();
        RectTransform rectTransform = GetComponent<RectTransform>();
        rectTransform.sizeDelta = new Vector2(span * 55f, rectTransform.sizeDelta.y);

        _mood = moodValue;
    }
}
