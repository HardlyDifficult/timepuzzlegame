using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrentTimeline : MonoBehaviour
{
    public struct TransformData
    {
        public Vector3 position;
        public Quaternion rotation;

        public TransformData(Vector3 position, Quaternion rotation)
        {
            this.position = position;
            this.rotation = rotation;
        }
    }

    public List<TransformData> transformData = new List<TransformData>();
}
