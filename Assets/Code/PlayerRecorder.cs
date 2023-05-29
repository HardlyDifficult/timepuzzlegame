using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRecorder : MonoBehaviour
{
    CurrentTimeline timeline;

    private void Start()
    {
        timeline = FindAnyObjectByType<CurrentTimeline>();
    }

    void FixedUpdate()
    {
        // TODO
        timeline.timelineData.Add(new FrameActionData(transform.position, transform.rotation, false));
    }
}
