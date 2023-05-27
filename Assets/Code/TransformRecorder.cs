using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransformRecorder : MonoBehaviour
{
    CurrentTimeline timeline;

    private void Start()
    {
        timeline = FindAnyObjectByType<CurrentTimeline>();
    }

    void FixedUpdate()
    {
        timeline.transformData.Add(new CurrentTimeline.TransformData(transform.position, transform.rotation));
    }
}
