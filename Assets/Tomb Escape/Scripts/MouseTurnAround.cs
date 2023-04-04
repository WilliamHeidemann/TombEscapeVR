using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseTurnAround : MonoBehaviour
{
    [SerializeField] private float rotationSpeed;
    private void Update()
    {
        Rotation();
    }
    
    private void Rotation()
    {
        if (Input.GetMouseButton(1))
        {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
            var mouseX = Input.GetAxis("Mouse X") * rotationSpeed;
            var mouseY = -Input.GetAxis("Mouse Y") * rotationSpeed;
            transform.Rotate(Vector3.up, mouseX, Space.World);
            transform.Rotate(Vector3.right, mouseY, Space.Self);
        }
        else
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
    }
}
