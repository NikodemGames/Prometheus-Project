using UnityEngine;

public class QTESystem : MonoBehaviour
{
    public KeyCode[] keys; 
    public float timeLimit = 4.0f; 
    public bool active = false; 


    private float timer = 0.0f;
    private int currentKey = 0;

    void Update()
    {
        if (active)
        {
            timer += Time.deltaTime;
            if (timer > timeLimit)
            {
                Fail();
            }

            if (Input.GetKeyDown(keys[currentKey]))
            {
                currentKey++;
                if (currentKey >= keys.Length)
                {
                    Success();
                }
            }
        }
    }

    public void StartEvent()
    {
        active = true;
        currentKey = 0;
        timer = 0.0f;
    }

    private void Success()
    {
        active = false;
        Debug.Log("Quick time event successful!");
    }

    private void Fail()
    {
        active = false;
        Debug.Log("Quick time event failed.");
    }
}
