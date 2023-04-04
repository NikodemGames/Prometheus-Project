using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class TimelineManager : MonoBehaviour
{
    public PlayableDirector jumpChase;


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (jumpChase.state == PlayState.Paused)
            {
                jumpChase.Resume();
            }
            else
            {
                jumpChase.Pause();
            }
        }
    }



    public void PauseCutscene()
    {
        jumpChase.Pause();
    }

}