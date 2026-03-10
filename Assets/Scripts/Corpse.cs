using UnityEngine;

public class Corpse : MonoBehaviour
{
    [SerializeField]
    protected MeshRenderer corpseRenderer;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        FlashOverlay.Flash(Color.red, 2);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SetCorpseTexture(Texture2D newCorpse)
    {
        corpseRenderer.material.mainTexture = newCorpse;
    }
}
