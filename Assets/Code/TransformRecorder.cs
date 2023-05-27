using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransformRecorder : MonoBehaviour
{
    public struct TransformData
    {
        Vector3 position;
        Quaternion rotation;

        public TransformData(Vector3 position, Quaternion rotation)
        {
            this.position = position;
            this.rotation = rotation;
        }
    }

    public List<TransformData> transformData = new List<TransformData>();

    void FixedUpdate()
    {
        transformData.Add(new TransformData(transform.position, transform.rotation));
    }
}
