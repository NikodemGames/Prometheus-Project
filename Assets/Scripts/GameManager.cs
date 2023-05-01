using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

public class GameManager : MonoBehaviour
{
    public PlayableDirector sceneOne;
    public PlayableDirector sceneTwo;
    public Rigidbody rb;
    

    // Start is called before the first frame update

    private void Update()
    {
        if (sceneOne.isActiveAndEnabled || sceneTwo.isActiveAndEnabled)
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
        sceneTwo.gameObject.SetActive(false);

    }

}
