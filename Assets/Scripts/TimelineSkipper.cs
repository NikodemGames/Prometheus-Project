using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Playables;

public class TimelineSkipper : MonoBehaviour
{
    public KeyCode skipKey = KeyCode.Escape;
    PlayableDirector timeline;
    bool skipped;

    private void Start()
    {
        timeline = GetComponent<PlayableDirector>();
    }
    private void Update()
    {
        
        if (Input.GetKeyDown(skipKey))
        {
            skipped = true;
        }
        if (skipped)
        {
            timeline.time += 0.1f;
        }
        if (timeline.time >= timeline.duration)
        {
            skipped = false;
        }
    }
}
