using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Card : MonoBehaviour
{
    [SerializeField]
    public CardInfo card = null;

    [SerializeField]
    protected RawImage front;

    [SerializeField]
    protected Image cardImage;

    [SerializeField]
    protected MeshRenderer worldMesh;

    // [SerializeField]
    // protected RawImage back;

    [SerializeField]
    protected TMP_Text titleText;

    [SerializeField]
    protected TMP_Text descriptionText;

    [SerializeField]
    protected Camera _camera;

    [SerializeField]
    protected RenderTexture _renderTextureBase;

    [SerializeField]
    protected float hoverScale = 1.2f;

    [SerializeField]
    protected Vector3 hoverPositionOffset = new Vector3(0, -0.5f, 0.5f);

    [SerializeField]
    protected float baseScale = 1.0f;

    public UnityEvent onStartHover;

    public UnityEvent onStopHover;

    public UnityEvent onClicked;

    private Vector3 _positionOffset = Vector3.zero;

    public void UpdateHovered()
    {
        float uniformScale = transform.localScale.x;
        float nextUniformScale = Mathf.MoveTowards(uniformScale, hoverScale, Time.deltaTime * 4f);
        // transform.localScale = Vector3.one * nextUniformScale;

        _positionOffset = Vector3.MoveTowards(_positionOffset, hoverPositionOffset, Time.deltaTime * 22f);
    }

    public void UpdateUnhovered()
    {
        float uniformScale = transform.localScale.x;
        float nextUniformScale = Mathf.MoveTowards(uniformScale, baseScale, Time.deltaTime * 28f);
        // transform.localScale = Vector3.one * nextUniformScale;

        _positionOffset = Vector3.MoveTowards(_positionOffset, Vector3.zero, Time.deltaTime * 26f);
    }

    public void Bind(CardInfo newCard)
    {
        card = newCard;
        front.texture = card.FrontTexture;
        descriptionText.text = card.Description;
        // back.texture = card.BackTexture;
        cardImage.sprite = card.cardImage;
        titleText.text = card.name;

        _camera.forceIntoRenderTexture = true;
        _camera.targetTexture = new RenderTexture(_renderTextureBase);

        worldMesh.material.mainTexture = _camera.targetTexture;

        _camera.Render();
    }

    public CardInfo GetCard()
    {
        return card;
    }

    public void OnMouseEnter()
    {
        onStartHover.Invoke();
    }

    public void OnMouseExit()
    {
        onStopHover.Invoke();
    }

    public void OnMouseDown()
    {
        onClicked.Invoke();
    }

    public Vector3 GetPositionOffset()
    {
        return _positionOffset;
    }
}
