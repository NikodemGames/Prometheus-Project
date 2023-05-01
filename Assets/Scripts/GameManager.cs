using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;
using UnityEngine.Timeline;

public class GameManager : MonoBehaviour
{
    public PlayableDirector sceneOne;
    public PlayableDirector sceneTwo;
    public PlayableDirector sceneWin;
    public Rigidbody rb;
    public GameObject enemyWin;
    



    // Start is called before the first frame update

    private void Update()
    {
        if (sceneOne.isActiveAndEnabled || sceneTwo.isActiveAndEnabled || sceneWin.isActiveAndEnabled)
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
        sceneWin.gameObject.SetActive(false);
        enemyWin.gameObject.SetActive(false);

    }

    public void GameOver()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

}
