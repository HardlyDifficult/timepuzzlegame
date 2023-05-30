using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerRecorder : MonoBehaviour
{
    CurrentTimeline timeline;
    PlayerInteractor interactor;

    List<ActionType> actions = new List<ActionType>();
    Vector2 moveDirection;
    Vector2 lookDirection;

    private void Start()
    {
        timeline = FindAnyObjectByType<CurrentTimeline>();
        interactor = GetComponent<PlayerInteractor>();
    }

    void OnFire(InputValue value)
    {
        if (value.Get<float>() == 1)
        {
            actions.Add(ActionType.Fire);
        }
    }

    void OnJump()
    {
        actions.Add(ActionType.Jump);
    }

    void OnMove(InputValue value)
    {
        moveDirection = value.Get<Vector2>();
    }

    void OnLook(InputValue value)
    {
        lookDirection += value.Get<Vector2>();
    }

    void FixedUpdate()
    {
        timeline.timelineData.Add(
            new FrameActionData(actions.ToArray(), moveDirection, lookDirection)
        );
        lookDirection = Vector2.zero;
        actions.Clear();
    }
}
