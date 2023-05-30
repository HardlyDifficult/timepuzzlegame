using UnityEngine;

public sealed class ThirdPersonCamera : MonoBehaviour
{
    #region Data
    [Header("Target Settings")]
    CameraFollowTarget target;

    [SerializeField, Min(0)]
    float _followDistance = 5f;

    [Header("Orbit Settings")]
    [SerializeField, Min(0)]
    float _orbitSpeed = .5f;

    [SerializeField]
    Vector2 _verticalLimits = new Vector2(-30, 80);

    [SerializeField]
    Vector2 _defaultAngle = new Vector2(30, 0);

    [Header("Physics Settings")]
    [SerializeField]
    LayerMask _collisionLayer = 0x1;

    [SerializeField]
    float _collisionResetSpeed = 2;

    private Camera _camera;

    private Vector2 _viewingAngle;
    private float _viewingDistance;
    #endregion

    #region Unity Functions
    private void Awake()
    {
        _camera = GetComponent<Camera>();

        _viewingAngle = _defaultAngle;
        _viewingDistance = _followDistance;
    }

    private void FixedUpdate()
    {
        if (target == null || !target.gameObject.activeInHierarchy)
        {
            target = FindFirstObjectByType<CameraFollowTarget>();
        }

        Quaternion targetRotation = target.shouldRotate
            ? target.transform.rotation * Quaternion.Euler(_viewingAngle)
            : transform.rotation;
        Vector3 targetPosition =
            target.transform.position + targetRotation * new Vector3(0, 0, -_followDistance);

        float maximumDistance = GetSafeOrbitDistance(
            target.transform.position,
            targetPosition,
            targetRotation,
            _followDistance
        );
        _viewingDistance = Mathf.Min(
            _viewingDistance + (_collisionResetSpeed * Time.fixedDeltaTime),
            maximumDistance
        );

        transform.SetPositionAndRotation(
            target.transform.position + targetRotation * new Vector3(0, 0, -_viewingDistance),
            targetRotation
        );
    }

    private void LateUpdate()
    {
        // ToDo: Get rotation input here!
        Vector2 rotationInput = Vector2.zero;
        Vector2 rotationMovement = new Vector2(-rotationInput.y * _camera.aspect, rotationInput.x);

        _viewingAngle += _orbitSpeed * rotationMovement;
        _viewingAngle.x = Mathf.Clamp(_viewingAngle.x, _verticalLimits.x, _verticalLimits.y);
    }
    #endregion

    #region Private Functions
    private float GetSafeOrbitDistance(
        Vector3 targetPosition,
        Vector3 cameraPosition,
        Quaternion cameraRotation,
        float maximumDistance
    )
    {
        Vector3[] clippingPoints = GetCameraClippingPoints(
            cameraPosition,
            cameraRotation,
            _camera.fieldOfView,
            _camera.nearClipPlane,
            _camera.aspect
        );

        /* The maximum distance is the distance from the target to the camera but the clipping points are slightly
         * further away from the target so that difference needs to be accounted for before and after the raycast.*/
        maximumDistance /= Mathf.Cos(_camera.fieldOfView * .5f * Mathf.Deg2Rad);

        for (int i = 0; i < clippingPoints.Length; i++)
        {
            Vector3 direction = clippingPoints[i] - targetPosition;

            if (
                Physics.Raycast(
                    targetPosition,
                    direction,
                    out RaycastHit hit,
                    maximumDistance,
                    _collisionLayer
                )
            )
            {
                float distance =
                    hit.distance * Mathf.Cos(_camera.fieldOfView * .5f * Mathf.Deg2Rad);
                maximumDistance = Mathf.Min(maximumDistance, distance);
            }
        }

        return maximumDistance;
    }

    private Vector3[] GetCameraClippingPoints(
        Vector3 position,
        Quaternion rotation,
        float fov,
        float nearClip,
        float aspect
    )
    {
        float height = Mathf.Tan(fov * .5f * Mathf.Deg2Rad) * nearClip;
        float width = height * aspect;

        return new Vector3[]
        {
            position + (rotation * new Vector3(-width, height, nearClip)),
            position + (rotation * new Vector3(width, height, nearClip)),
            position + (rotation * new Vector3(-width, -height, nearClip)),
            position + (rotation * new Vector3(width, -height, nearClip)),
        };
    }
    #endregion
}
