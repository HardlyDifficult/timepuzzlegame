using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct FrameActionData
{
    public Vector3 position;
    public Quaternion rotation;
    public bool isInteracting;

    public FrameActionData(Vector3 position, Quaternion rotation, bool isInteracting)
    {
        this.position = position;
        this.rotation = rotation;
        this.isInteracting = isInteracting;
    }
}

public class CurrentTimeline : MonoBehaviour
{
    public event Action<bool> onTimeDirectionChange;

    public List<FrameActionData> timelineData = new List<FrameActionData>();
    
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
