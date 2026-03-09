using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayButton : MonoBehaviour
{
    public void OnPlayButtonPressed()
    {
        //Load next scene
        SceneManager.LoadScene(1);
    }
}
