using UnityEngine;
using UnityEngine.UI;

public class MoodLightbulb : MonoBehaviour
{

    [SerializeField] private Image image;
    [SerializeField] private Image glow;
    public int moodValue;

    public Gradient colors;

    public bool Lit
    {
        get => lit;
        set
        {
            lit = value;
            glow.gameObject.SetActive(lit);
        }
    }

    private bool lit;

    public void Update()
    {
        // flicker

        // if (Random.Range(0f, 1f) > 0.95f)
        // {
        // glow.SetActive(false);
        // }
        // else
        // {
        // glow.SetActive(lit);
        // }

        float pct = (float)transform.GetSiblingIndex() / (float)Game.instance.moodThresholds.thresholds.Length * 0.5f;
        glow.color = colors.Evaluate(pct);
    }
}
