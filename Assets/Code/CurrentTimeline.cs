using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ActionType
{
    Fire,
    Jump
}

public struct FrameActionData
{
    public ActionType[] actions;
    public Vector2 lookDirection;
    public Vector2 moveDirection;

    public FrameActionData(ActionType[] actions, Vector2 moveDirection, Vector2 lookDirection)
    {
        this.actions = actions;
        this.moveDirection = moveDirection;
        this.lookDirection = lookDirection;
    }
}

public class CurrentTimeline : MonoBehaviour
{
    public event Action<bool> onTimeDirectionChange;

    public List<FrameActionData> timelineData = new List<FrameActionData>();

    public Vector3 initialRotation;

    public Vector3 initialPosition;

    bool _isForwardTime = true;

    public int rewindSpeed = 3;

    public bool isForwardTime
    {
        get { return _isForwardTime; }
        set
        {
            _isForwardTime = value;
            onTimeDirectionChange(_isForwardTime);
        }
    }
}
