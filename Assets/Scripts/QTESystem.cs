using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;

public class QTESystem : MonoBehaviour
{
    public float timeLimit = 3f;
    public bool qteActive = false;
    


    void Update()
    {
        if (qteActive)
        {
            
            timeLimit -= Time.deltaTime / Time.timeScale;
            if (timeLimit <= 0 || (Input.anyKeyDown && Input.GetKey(KeyCode.Q) == false))
            {
                EndQTE(false);               
            }
            if (Input.GetKey(KeyCode.Q))
            {
                EndQTE(true);       
            }
            Time.timeScale = 0.05f;
        }
        else
        {
            Time.timeScale = 1f;
        }

    }

    public void StartQTE()
    {
        qteActive = true;
        timeLimit = 3f;
    }

    private void EndQTE(bool success)
    {
        qteActive = false;
        if (success)
        {
            Debug.Log("Holy Shmoly Macaroni you did it");
            Time.timeScale = 1f;
            //gameObject.SetActive(false);    
            //Destroy(gameObject);
        }
        else
        {
            Debug.Log("XDD consider other games m8");
            //gameObject.SetActive(false);
            //Destroy(gameObject);
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

}