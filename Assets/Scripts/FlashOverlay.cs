using UnityEngine;
using UnityEngine.UI;

public class FlashOverlay : MonoBehaviour
{
    public float flashDecaySpeed = 10;

    public Image overlay;

    private Color target;

    private Color start;

    private static FlashOverlay flashOverlay;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        flashOverlay = this;

        target = Color.clear;
        start = Color.black;
    }

    // Update is called once per frame
    void Update()
    {
        overlay.color = Color.Lerp(overlay.color, target, Time.deltaTime * flashDecaySpeed);
    }

    public static void Flash(Color color, float speed)
    {
        Color colorClear = new Color(color.r, color.g, color.b, 0);
        flashOverlay.overlay.color = color;
        flashOverlay.target = colorClear;
        flashOverlay.flashDecaySpeed = speed;
    }
}
