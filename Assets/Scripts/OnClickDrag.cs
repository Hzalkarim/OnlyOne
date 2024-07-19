using UnityEngine;

public class OnClickDrag : MonoBehaviour
{

    public Camera mainCamera;
    private Vector3 depth;

    public bool isActive;

    private void Awake()
    {
        mainCamera = Camera.main;
    }

    void OnMouseDown()
    {
        if (!isActive)
            return;
        depth = transform.position - MouseWorldPosition();
        transform.GetComponent<Collider>().enabled = false;
    }

    void OnMouseUp()
    {
        if (!isActive)
            return;
        var rayOrigin = mainCamera.transform.position;
        var rayDirection = MouseWorldPosition() - mainCamera.transform.position;
        RaycastHit hitInfo;
        if (Physics.Raycast(rayOrigin, rayDirection, out hitInfo))
        {
            transform.position = hitInfo.transform.position;
        }
        transform.GetComponent<Collider>().enabled = true;
    }

    public void OnMouseDrag()
    {
        if (!isActive)
            return;
        transform.position = MouseWorldPosition() + depth;
    }

    Vector3 MouseWorldPosition()
    {
        var mouseScreenPos = Input.mousePosition;
        mouseScreenPos.z = Camera.main.WorldToScreenPoint(transform.position).z;
        return Camera.main.ScreenToWorldPoint(mouseScreenPos);
    }
}
