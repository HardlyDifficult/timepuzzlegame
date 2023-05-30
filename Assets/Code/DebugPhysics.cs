namespace UnityEngine
{
    public static class DebugPhysics
    {
        #region Public Functions
        public static bool SphereCast(
            Vector3 origin,
            float radius,
            Vector3 direction,
            out RaycastHit hitInfo,
            float maxDistance = Mathf.Infinity,
            int layerMask = 0x1
        )
        {
            bool sphereHit = Physics.SphereCast(
                origin,
                radius,
                direction,
                out hitInfo,
                maxDistance,
                layerMask
            );

            float displayDistance = sphereHit ? hitInfo.distance : maxDistance;
            Vector3 displayPosition = origin + (direction.normalized * displayDistance);

            Debug.DrawLine(origin, displayPosition, Color.red);
            AdvancedDebug.DrawSphere(displayPosition, radius, Color.red);

            return sphereHit;
        }

        public static bool Raycast(
            Vector3 origin,
            Vector3 direction,
            out RaycastHit hitInfo,
            float maxDistance = Mathf.Infinity,
            int layerMask = 0x1
        )
        {
            bool rayHit = Physics.Raycast(origin, direction, out hitInfo, maxDistance, layerMask);

            float displayDistance = rayHit ? hitInfo.distance : maxDistance;
            Vector3 displayPosition = origin + (direction.normalized * displayDistance);

            Debug.DrawLine(origin, displayPosition, Color.red);
            return rayHit;
        }
        #endregion
    }
}
