using UnityEngine;

public class Guest : MonoBehaviour
{
    [SerializeField]
    protected float moveSpeed = 3;

    [SerializeField]
    protected float restDurationMin = 1;

    [SerializeField]
    protected float restDurationMax = 8;

    [SerializeField]
    protected Transform graphicsParent;

    private Vector3 _destination = Vector3.zero;

    private float _restTimer = 0;

    // just like me fr fr
    private bool _rested = false;

    [System.Serializable]
    public enum State
    {
        Move,
        Rest,
        PostRest
    }

    protected State state = State.Move;

    private float _moveTimer = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

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

            SetGraphicsHeightOffset(Mathf.Sin(_moveTimer * 3f) * 0.1f);
            SetGraphicsRotation(Mathf.Cos(_moveTimer * 8f) * 15f);
            _moveTimer += Time.deltaTime;
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

    }

    public void SetMoveTarget(Vector3 newTarget)
    {
        _destination = newTarget;
        _restTimer = 0;
        state = State.Move;
    }
}
