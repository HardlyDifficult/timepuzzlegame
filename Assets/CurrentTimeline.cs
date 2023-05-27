using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

public class CurrentTimeline : MonoBehaviour
{
    public event Action<bool> onTimeDirectionChange;

    public List<TransformData> transformData = new List<TransformData>();
    bool _isForwardTime = true;
    public bool isForwardTime
    {
        get
        {
            return _isForwardTime;
        }
        set
        {
            _isForwardTime = value;
            onTimeDirectionChange(_isForwardTime);
        }
    }
}
