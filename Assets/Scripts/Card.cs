using DG.Tweening;
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
    protected Transform graphicsParent;

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

    void Start()
    {
        // graphicsParent.localEulerAngles
        graphicsParent.localEulerAngles = Vector3.up * 180;
        _positionOffset = new Vector3(0, -6, 0);

        // graphicsParent.localPosition = new Vector3(0, -1, 0);
        graphicsParent.DOLocalRotate(Vector3.zero, 0.9f);
    }

    void Update()
    {
        // graphicsParent.localEulerAngles = Vector3.MoveTowards(graphicsParent.localEulerAngles, Vector3.zero, Time.deltaTime * 100);
    }

    public void UpdateHovered()
    {
        float uniformScale = graphicsParent.localScale.x;
        float nextUniformScale = Mathf.MoveTowards(uniformScale, hoverScale, Time.deltaTime * 18f);
        graphicsParent.localScale = Vector3.one * nextUniformScale;

        _positionOffset = Vector3.MoveTowards(_positionOffset, hoverPositionOffset, Time.deltaTime * 22f);
    }

    public void UpdateUnhovered()
    {
        float uniformScale = graphicsParent.localScale.x;
        float nextUniformScale = Mathf.MoveTowards(uniformScale, baseScale, Time.deltaTime * 12f);
        graphicsParent.localScale = Vector3.one * nextUniformScale;


        _positionOffset = Vector3.MoveTowards(_positionOffset, Vector3.zero, Time.deltaTime * 26f);
    }

    public void Bind(CardInfo newCard)
    {
        card = newCard;
        front.texture = card.FrontTexture;
        descriptionText.text = card.Description;
        // back.texture = card.BackTexture;
        cardImage.sprite = card.cardImage;
        titleText.text = card.Name;

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

    public Transform GetGraphicsTransform()
    {
        return graphicsParent;
    }
}
