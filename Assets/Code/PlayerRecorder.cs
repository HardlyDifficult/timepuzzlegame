using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRecorder : MonoBehaviour
{
    CurrentTimeline timeline;
    PlayerInteractor interactor;

    private void Start()
    {
        timeline = FindAnyObjectByType<CurrentTimeline>();
        interactor = GetComponent<PlayerInteractor>();
    }

    void FixedUpdate()
    {
        // TODO
        timeline.timelineData.Add(new FrameActionData(transform.position, transform.rotation, interactor.isInteracting));
    }
}
