using UnityEngine;
using UnityEngine.UI;

public class MoodLightbulb : MonoBehaviour
{
    [SerializeField] private Sprite litSprite;
    [SerializeField] private Sprite unlitSprite;
    [SerializeField] private Image image;
    public int moodValue;

    public bool Lit
    {
        get => lit;
        set
        {
            lit = value;
            image.sprite = value ? litSprite : unlitSprite;
        }
    }

    private bool lit;   
}
