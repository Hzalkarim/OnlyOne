using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnClickRotate : MonoBehaviour
{
    public Camera mainCamera;

    //public bool isActive;
    private float multiplier = .5f;

    private Vector3 lastMousePosition;

    private void Awake()
    {
        mainCamera = Camera.main;
    }

    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            var delta = GetDeltaMousePosition();
            transform.Rotate(mainCamera.transform.right * delta.x * multiplier, Space.World);
            transform.Rotate(mainCamera.transform.up * delta.y * multiplier, Space.World);
        }
    }

    private Vector3 GetDeltaMousePosition()
    {
        var delta = Input.mousePosition - lastMousePosition;
        lastMousePosition = Input.mousePosition;
        return delta;
    }
}
