using UnityEngine;
using UnityEngine.UI;

public class MoodLightbulb : MonoBehaviour
{

    [SerializeField] private Image image;
    [SerializeField] private GameObject glow;
    public int moodValue;

    public bool Lit
    {
        get => lit;
        set
        {
            lit = value;
            glow.SetActive(lit);
        }
    }

    private bool lit;   
}
