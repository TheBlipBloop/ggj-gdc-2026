using UnityEngine;
using UnityEngine.Events;

public class HoverCollision : MonoBehaviour
{
    public UnityEvent onMouseEnterEvent;
    public UnityEvent onMouseExitEvent;

    public void OnMouseEnter()
    {
        onMouseEnterEvent.Invoke();
    }

    public void OnMouseExit()
    {
        onMouseExitEvent.Invoke();
    }
}
