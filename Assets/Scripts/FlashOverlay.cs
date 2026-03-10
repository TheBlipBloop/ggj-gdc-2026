using UnityEngine;
using UnityEngine.UI;

public class FlashOverlay : MonoBehaviour
{
    public float flashDecaySpeed = 10;

    public Image overlay;

    private Color overrideColor = Color.clear;



    private static FlashOverlay flashOverlay;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        flashOverlay = this;
        overrideColor = Color.white;
        overrideColor.a = 0;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public static void Flash(Color color, float duration)
    {
        Color colorClear = new Color(color.r, color.g, color.b, 0);
        flashOverlay.overrideColor = colorClear;
    }
}
