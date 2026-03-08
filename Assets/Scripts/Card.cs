using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Card : MonoBehaviour
{
    [SerializeField]
    protected CardInfo card = null;

    [SerializeField]
    protected RawImage front;

    [SerializeField]
    protected RawImage back;

    [SerializeField]
    protected TMP_Text titleText;

    [SerializeField]
    protected Camera _camera;

    [SerializeField]
    protected RenderTexture _renderTextureBase;

    void Start()
    {
        _camera.forceIntoRenderTexture = true;
        _camera.targetTexture = new RenderTexture(_renderTextureBase);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Bind(CardInfo newCard)
    {
        card = newCard;
        front.texture = card.FrontTexture;
        back.texture = card.BackTexture;
        titleText.text = card.name;

        _camera.Render();
    }

    public CardInfo GetCard()
    {
        return card;
    }
}
