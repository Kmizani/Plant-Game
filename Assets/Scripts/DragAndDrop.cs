using UnityEngine;
using UnityEngine.EventSystems;

public class Draggable : MonoBehaviour, IPointerDownHandler, IDragHandler, IPointerUpHandler
{
    private Vector3 offset;

    public void OnPointerDown(PointerEventData eventData)
    {
        // Calculate offset between the mouse position and the object's position
        offset = transform.position - Camera.main.ScreenToWorldPoint(eventData.position);
    }

    public void OnDrag(PointerEventData eventData)
    {
        // Update object's position based on mouse movement
        Vector3 newPos = Camera.main.ScreenToWorldPoint(eventData.position) + offset;
        transform.position = new Vector3(newPos.x, newPos.y, transform.position.z);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        // TODO add logic to snap the object to a grid or choose a drop positions
    }
}