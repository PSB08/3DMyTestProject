using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float mouseSensitivity = 100f;
    public float jumpHeight = 2f;

    private float xRotation = 0f;
    private CharacterController controller;
    private Vector3 velocity;
    private float gravity = -9.81f;
    public bool isResetting = false;
    private bool isStopTime = false;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        controller = GetComponent<CharacterController>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            if (isStopTime)
                Time.timeScale = 1;
            else
                Time.timeScale = 0;
            isStopTime = !isStopTime;
        }
        

        if (isResetting) return;

        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.unscaledDeltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.unscaledDeltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        float yRotation = transform.eulerAngles.y + mouseX;

        transform.rotation = Quaternion.Euler(xRotation, yRotation, 0f);

        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");

        Vector3 move = transform.right * moveX + transform.forward * moveZ;
        controller.Move(move * moveSpeed * Time.unscaledDeltaTime);

        if (controller.isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        if (Input.GetKeyDown(KeyCode.Space) && controller.isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        velocity.y += gravity * Time.unscaledDeltaTime;
        controller.Move(velocity * Time.unscaledDeltaTime);
    }



}
