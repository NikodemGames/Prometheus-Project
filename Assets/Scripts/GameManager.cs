using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

public class GameManager : MonoBehaviour
{
    public PlayableDirector sceneOne;
    public PlayableDirector sceneTwo;
    public PlayableDirector sceneWin;
    public Rigidbody rb;
    public GameObject enemyWin;
    private Dictionary<string, Vector3> originalPositions = new Dictionary<string, Vector3>();

    private void Awake()
    {
        // Store the player's original position
        originalPositions.Add("Player", rb.transform.position);
    }

    private void Update()
    {
        if (sceneOne.isActiveAndEnabled || sceneTwo.isActiveAndEnabled || sceneWin.isActiveAndEnabled)
        {
            // Reset the player's position to the original position
            if (originalPositions.ContainsKey("Player"))
            {
                rb.transform.position = originalPositions["Player"];
            }
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
        sceneWin.gameObject.SetActive(false);
        enemyWin.gameObject.SetActive(false);
    }
}
