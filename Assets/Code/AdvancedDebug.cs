namespace UnityEngine
{
    public static class AdvancedDebug
    {
        #region Public Functions
        public static void DrawSphere(Vector3 origin, float radius, Color colour)
        {
            DrawCircle(origin, Vector3.up, radius, colour);
            DrawCircle(origin, Vector3.right, radius, colour);
            DrawCircle(origin, Vector3.forward, radius, colour);
        }

        public static void DrawCircle(Vector3 origin, Vector3 normal, float radius, Color colour)
        {
            Quaternion rotation = Quaternion.LookRotation(normal);
            Vector3 previousPosition = origin + rotation * (Vector3.up * radius);

            for (int i = 0; i < 16; i++)
            {
                float angle = ((i + 1f) / 16f) * Mathf.PI * 2;
                Vector3 currentPosition =
                    origin
                    + rotation * new Vector3(Mathf.Sin(angle) * radius, Mathf.Cos(angle) * radius);

                Debug.DrawLine(currentPosition, previousPosition, colour);
                previousPosition = currentPosition;
            }
        }
        #endregion
    }
}
