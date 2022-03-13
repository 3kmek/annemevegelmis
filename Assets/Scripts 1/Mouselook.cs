using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mouselook : MonoBehaviour
{
    [Range(50, 500)]
    public float sens;
    private float xRot = 0f;
    public Transform body;

    private void Update()
    {
        //Mouse Look
        float rotX = Input.GetAxisRaw("Mouse X") * sens * Time.deltaTime;
        float rotY = Input.GetAxisRaw("Mouse Y") * sens * Time.deltaTime;

        xRot -= rotY;
        xRot = Mathf.Clamp(xRot, -80f, 80f);
        transform.localRotation = Quaternion.Euler(xRot, 0, 0);

        body.Rotate(Vector3.up * rotX);

        //Cursor Management
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.lockState = CursorLockMode.Locked;
    }
}
