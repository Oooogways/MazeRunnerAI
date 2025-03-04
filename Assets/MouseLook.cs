using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public float mouseSensitivity = 100f;  // Lowered sensitivity
    public Transform playerBody;

    float xRotation = 0f;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        // Get mouse input without Time.deltaTime for direct response
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * 0.01f;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * 0.01f;


        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        // Apply vertical rotation only to the camera
        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

        // Rotate the player horizontally
        if (playerBody != null)
            playerBody.Rotate(Vector3.up * mouseX);
    }
}
