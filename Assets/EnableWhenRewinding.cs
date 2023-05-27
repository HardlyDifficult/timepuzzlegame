using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableWhenRewinding : MonoBehaviour
{
    CurrentTimeline timeline;

    void Start()
    {
        timeline = FindFirstObjectByType<CurrentTimeline>();
        timeline.onTimeDirectionChange += Timeline_onTimeDirectionChange;
        Timeline_onTimeDirectionChange(timeline.isForwardTime);
    }

    private void Timeline_onTimeDirectionChange(bool isForwardTime)
    {
        gameObject.SetActive(!isForwardTime);
    }
}
