using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

public class GameManager : MonoBehaviour
{
    public PlayableDirector sceneOne;
    public Rigidbody rb;
    

    // Start is called before the first frame update

    private void Update()
    {
        if (sceneOne.isActiveAndEnabled)
        {
            rb.isKinematic = true;

        }
        else
        {
            rb.isKinematic = false;
        }
    }

    public void Disable()
    {
        sceneOne.gameObject.SetActive(false);

    }

}
