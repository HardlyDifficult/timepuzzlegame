using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class TransformRewinder : GenericInteractor
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
    }

    private void OnDestroy()
    {
        timeline.isForwardTime = true;
    }

    // void OnRewindTime(InputValue value)
    // {
    //     var isRewinding = value.Get<float>() == 1;
    //     if (!isRewinding)
    //     {
    //         shouldResume = true;
    //     }
    // }

    void FixedUpdate()
    {
        if (currentFrame <= 0)
        {
            shouldResume = true;
        }

        if (shouldResume)
        {
            // TODO give it the timeline
            Instantiate(historicalBobPrefab, transform.position, transform.rotation);
            timeline.timelineData.RemoveRange(
                currentFrame,
                timeline.timelineData.Count - currentFrame
            );

            // TODO position it in the next pod
            var timeMachine = FindFirstObjectByType<TimeMachine>();
            TimeMachinePod nextPod = null;
            foreach (var pod in timeMachine.pods)
            {
                if (!pod.hasTimeline)
                {
                    nextPod = pod;
                    break;
                }
            }
            if (!nextPod)
            {
                Debug.LogError("No empty pod found");
            }
            nextPod.hasTimeline = true;
            Instantiate(playerBobPrefab, nextPod.transform.position, nextPod.transform.rotation);
            Destroy(gameObject);
            return;
        }

        currentFrame -= timeline.rewindSpeed; // TODO consider faster rewind

        if (currentFrame <= 0)
        {
            currentFrame = 0;
            // Ignore rewind, at start of timeline
            return;
        }

        // Travel backwards through time
        var frame = timeline.timelineData[currentFrame];

        // TODO
        // transform.SetPositionAndRotation(frame.position, frame.rotation);
        // OnInteract(frame.isInteracting);
    }
}
