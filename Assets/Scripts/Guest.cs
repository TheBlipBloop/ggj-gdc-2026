using UnityEngine;

public class Guest : MonoBehaviour
{
    [SerializeField]
    public float moveSpeed = 3;
    public float speeFactor = 1f;

    [SerializeField]
    protected float restDurationMin = 1;

    [SerializeField]
    protected float restDurationMax = 8;

    [SerializeField]
    protected Transform graphicsParent;

    [System.Serializable]
    protected struct GuestTextureSet
    {
        public Texture2D guest;
        public Texture2D corpse;

    }

    [SerializeField]
    protected GuestTextureSet[] guestTextures;

    [SerializeField]
    protected MeshRenderer meshRenderer;

    [SerializeField]
    protected Color exitTint = new Color(0.7f, 0.7f, 0.7f, 1f);

    private Vector3 _destination = Vector3.zero;

    private float _restTimer = 0;


    [System.Serializable]
    public enum State
    {
        Move,
        Rest,
        PostRest
    }

    protected State state = State.Move;

    public bool exiting = false;

    private float _moveTimer = 0;

    [SerializeField]
    protected GameObject corpsePrefab;

    private int textureSetIndex = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        textureSetIndex = Random.Range(0, guestTextures.Length);
        meshRenderer.material.mainTexture = guestTextures[textureSetIndex].guest;
    }

    // Update is called once per frame
    void Update()
    {
        _restTimer -= Time.deltaTime;

        if (state == State.Move)
        {
            bool complete;
            Move(out complete);

            if (complete)
            {
                _restTimer = Random.Range(restDurationMin, restDurationMax);
                state = State.Rest;
            }

            if (complete && exiting)
            {
                Destroy(gameObject);
            }

            SetGraphicsHeightOffset(Mathf.Sin(_moveTimer * 3f) * 0.1f);
            SetGraphicsRotation(Mathf.Cos(_moveTimer * 8f) * 15f);
            _moveTimer += Time.deltaTime * speeFactor;
        }

        if (state == State.Rest)
        {
            _restTimer -= Time.deltaTime;

            if (_restTimer <= 0)
            {
                state = State.PostRest;
            }
            _moveTimer = 0;
        }

        if (state == State.PostRest)
        {
            // Do nothing until told to by the enclosure
        }


        // Vector3 originalPosition = graphicsParent.localPosition;
        // Vector3 sortedPosition = new Vector3(originalPosition.x, originalPosition.y, originalPosition.y / 100f);
        // graphicsParent.localPosition = sortedPosition;
    }

    private void Move(out bool moveComplete)
    {
        Vector3 nextPosition = Vector3.MoveTowards(transform.position, _destination, Time.deltaTime * moveSpeed);
        transform.position = nextPosition;

        moveComplete = Vector3.Distance(nextPosition, _destination) < 0.01f;
    }

    private void SetGraphicsHeightOffset(float newOffset)
    {
        graphicsParent.localPosition = Vector3.up * newOffset;
    }

    private void SetGraphicsRotation(float degrees)
    {
        graphicsParent.localEulerAngles = Vector3.forward * degrees;
    }

    public bool IsDoneResting()
    {
        return state == State.PostRest;
    }

    public void Sacrifice()
    {
        // Destroy, spawn corpse, oowy goowy sound  TODO
        Destroy(gameObject);
        GameObject corpse = Instantiate(corpsePrefab, transform.position, transform.rotation);
        corpse.GetComponent<Corpse>().SetCorpseTexture(guestTextures[textureSetIndex].corpse);
    }

    public void SetMoveTarget(Vector3 newTarget)
    {
        _destination = newTarget;
        _restTimer = 0;
        state = State.Move;
    }

    public void SetAsExiting()
    {
        exiting = true;
        meshRenderer.material.color = exitTint;
    }
}
