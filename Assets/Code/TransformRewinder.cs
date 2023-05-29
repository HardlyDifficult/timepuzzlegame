using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class TransformRewinder : MonoBehaviour
{
    [SerializeField]
    GameObject playerBobPrefab;
    [SerializeField]
    GameObject historicalBobPrefab;

    CurrentTimeline timeline;
    public int currentFrame;
    bool shouldResume;

    private void Awake()
    {
        timeline = FindFirstObjectByType<CurrentTimeline>();
        timeline.isForwardTime = false;
        currentFrame = timeline.timelineData.Count - 1;
        Debug.Log(currentFrame + " <- at awake");
    }

    private void OnDestroy()
    {
        timeline.isForwardTime = true;
    }

    void OnRewindTime(InputValue value)
    {
        var isRewinding = value.Get<float>() == 1;
        if (!isRewinding)
        {
            shouldResume = true;
        }
    }

    void FixedUpdate()
    {
        if (shouldResume)
        {
            // TODO give it the timeline
            Instantiate(historicalBobPrefab, transform.position, transform.rotation);
            timeline.timelineData.RemoveRange(currentFrame, timeline.timelineData.Count - currentFrame);
            Instantiate(playerBobPrefab, transform.position, transform.rotation);
            Destroy(gameObject);
            return;
        }

        if (currentFrame <= 0)
        {
            // Ignore rewind, at start of timeline
            return;
        }
        else
        {
            currentFrame--; // TODO consider faster rewind
        }

        // Travel backwards through time
        var frame = timeline.timelineData[currentFrame];
        transform.SetPositionAndRotation(frame.position, frame.rotation);
    }
}
