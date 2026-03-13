using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public float mouseSensitivity = 150f;
    public float distance = 10f;
    public float height = 3f;

    float xRotation = 20f;
    float yRotation = 0f;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void LateUpdate()
    {
        if (target == null) return;

        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        yRotation += mouseX;
        xRotation -= mouseY;

        xRotation = Mathf.Clamp(xRotation, -40f, 60f);

        Quaternion rotation = Quaternion.Euler(xRotation, yRotation, 0);

        Vector3 position = target.position - (rotation * Vector3.forward * distance)
                           + Vector3.up * height;

        transform.position = position;
        transform.rotation = rotation;
    }
}