
using UnityEngine;

public class ThirdPersonCamera : MonoBehaviour
{
    public Transform target;
    public float distance = 5f;
    public float height = 2f;
    public float rotationOffset = -15f; // Negative for a rear view
    public float smoothSpeed = 0.125f;

    void LateUpdate()
    {
        // Calculate desired position
        Vector3 desiredPosition = target.position - target.forward * distance;
        desiredPosition += Vector3.up * height;

        // Calculate desired rotation
        Quaternion desiredRotation = Quaternion.Euler(rotationOffset, target.eulerAngles.y, 0);

        // Smoothly interpolate to desired position and rotation
        transform.position = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);
        transform.rotation = Quaternion.Lerp(transform.rotation, desiredRotation, smoothSpeed * Time.deltaTime);
    }
}