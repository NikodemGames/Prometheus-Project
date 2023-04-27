using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class QTESystem : MonoBehaviour
{
    public float timeLimit = 3f;
    public bool qteActive = false;
    public QTETimeSlider QTS;
    public GameObject QTEPrompt;

    public GameObject gameOver;

    public delegate void QTEOutcomeEventHandler(bool succeeded);
    public static event QTEOutcomeEventHandler OnQTEOutcome;

    private void Start()
    {
        QTS.SetSliderMaxValue(timeLimit);
    }

    void Update()
    {
        if (qteActive)
        {
            Time.timeScale = 0f;
            timeLimit -= Time.unscaledDeltaTime;
            QTS.SetSliderValue(timeLimit);
            if (timeLimit <= 0 || (Input.anyKeyDown && Input.GetKey(KeyCode.Q) == false))
            {
                EndQTE(false);
            }
            if (Input.GetKey(KeyCode.Q))
            {
                EndQTE(true);
            }

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
            QTEPrompt.SetActive(false);
            OnQTEOutcome?.Invoke(true);
            gameObject.SetActive(false);    
        }
        else
        {
            gameOver.gameObject.SetActive(true);
            Debug.Log("XDD consider other games m8");
            Time.timeScale = 1f;
            QTEPrompt.SetActive(false);
            OnQTEOutcome?.Invoke(false);
     
        }
    }

    

}
