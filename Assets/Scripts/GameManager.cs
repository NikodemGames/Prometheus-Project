using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
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
    public GameObject rain;
    

    

    public bool isRoof;
    public bool isTrigger;
    



    // Start is called before the first frame update

    private void Update()
    {
        if (rain.transform.position.y > 10)
        {
            isRoof = true;
        }
        else
        {
            isRoof = false;
        }
        
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
