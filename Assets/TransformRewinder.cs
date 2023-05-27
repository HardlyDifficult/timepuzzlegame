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

    private void Start()
    {
        timeline = FindFirstObjectByType<CurrentTimeline>();
        currentFrame = timeline.transformData.Count - 1;
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
        currentFrame--; // TODO consider faster rewind
        if (currentFrame < 0)
        {
            // TODO: also cap the max we can travel back
            shouldResume = true;
        }

        if (shouldResume)
        {
            // TODO give it the timeline
            Instantiate(historicalBobPrefab, transform.position, transform.rotation);
            // TODO fix up the current timeline
            Instantiate(playerBobPrefab, transform.position, transform.rotation);
            Destroy(gameObject);
            return;
        }

        // Travel backwards through time
        var frame = timeline.transformData[currentFrame];
        transform.SetPositionAndRotation(frame.position, frame.rotation);
    }
}
