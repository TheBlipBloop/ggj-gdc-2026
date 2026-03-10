using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public GameObject creditsScreen;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ToggleCredits()
    {
        creditsScreen.SetActive(!creditsScreen.activeSelf);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
