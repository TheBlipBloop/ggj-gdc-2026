using UnityEngine;

public class MoodLabel : MonoBehaviour
{
    [SerializeField] private TMPro.TextMeshProUGUI label;

    public void SetLabel(int moodValue, int span)
    {
        label.text = (moodValue >= 0 ? "+" : "") + moodValue.ToString();
        RectTransform rectTransform = GetComponent<RectTransform>();
        rectTransform.sizeDelta = new Vector2(span * 55f, rectTransform.sizeDelta.y);
    }
}
