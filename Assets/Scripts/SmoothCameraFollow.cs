using UnityEngine;

public class SmoothCameraFollow : MonoBehaviour
{
    #region Variables

    private Vector3 _offset;
    [SerializeField] private Transform target;
    [SerializeField] private float smoothTime;
    private Vector3 _currentVelocity = Vector3.zero;

    #endregion

    #region Unity callbacks

    private void Awake() => _offset = transform.position - target.position;

    private void LateUpdate()
    {
        // Calculate target position with offset relative to target's forward direction
        Vector3 targetPosition = target.position + Vector3.Scale(_offset.normalized, Vector3.ProjectOnPlane(transform.position - target.position, target.up));

        // Calculate target rotation based on target's position and camera's up direction
        Quaternion targetRotation = Quaternion.LookRotation(target.position - transform.position, transform.up);

        // Smoothly move and rotate the camera towards the target
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref _currentVelocity, smoothTime);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, smoothTime * Time.deltaTime);
    }

    #endregion
}