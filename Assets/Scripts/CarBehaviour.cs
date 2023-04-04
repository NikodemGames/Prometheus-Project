using UnityEngine;

public class CarBehaviour: MonoBehaviour
{
    public float distance = 1f;
    public float speed = 1f;
    private Vector3 startPosition;

    void Start()
    {
        startPosition = transform.position;
    }

    void Update()
    {
        float pingPong = Mathf.PingPong(Time.time * speed, distance);
        transform.position = startPosition + Vector3.right * pingPong;
    }
}
