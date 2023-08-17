using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    [SerializeField] private float _sensivity = 100f;
    [SerializeField] private float _speed = 1;
    private float xRotation = 0.0f;
    private float yRotation = 0.0f;

    private void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
    private void Update()
    {
        Move();
        RotateCameraByMouse();
    }

    private void RotateCameraByMouse()
    {
        float mouseX = Input.GetAxis("Mouse X") * _sensivity;
        float mouseY = Input.GetAxis("Mouse Y") * _sensivity;

        yRotation += mouseX;
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90, 90);

        _camera.transform.eulerAngles = new Vector3(xRotation, yRotation, 0.0f);
        transform.eulerAngles = new Vector3(0f, yRotation, 0.0f);
    }

    private void Move()
    {
        float xMove = Input.GetAxis("Horizontal");
        float zMove = Input.GetAxis("Vertical");
        Vector3 _moveDirect = new Vector3(xMove, 0, zMove);
        Vector3 _delta = transform.TransformDirection(_moveDirect * Time.deltaTime * _speed);
        transform.position += _delta;
        
    }
}
