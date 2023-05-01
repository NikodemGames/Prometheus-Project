using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    // Movement variables
    [SerializeField] private float moveSpeed = 40f;
    [SerializeField] private float turnSpeed = 60f;

    private Animator animator;
    public GameObject qteObject;
    public GameObject chaseCutscene;

    // Rigidbody component
    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        // Get the Rigidbody component
        rb = GetComponent<Rigidbody>();

        animator = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        // Get the horizontal input
        float turn = Input.GetAxis("Horizontal");

        // Calculate the rotation vector
        Vector3 rotation = new Vector3(0f, turn * turnSpeed * Time.deltaTime, 0f);

        // Apply the rotation to the transform
        transform.Rotate(rotation);

        // Get the vertical input
        float moveVertical = Input.GetAxis("Vertical");

        // Calculate the movement vector
        Vector3 movement = moveSpeed * moveVertical * Time.deltaTime * transform.forward;

        // Apply the movement to the Rigidbody
        rb.MovePosition(transform.position + movement);




        if (movement != Vector3.zero)
        {
            animator.SetBool("isMoving", true);
        }
        else
        {
            animator.SetBool("isMoving", false);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("chaseTag"))
        {
            chaseCutscene.SetActive(true);
        }
        if (other.gameObject.CompareTag("QTETag"))
        {
            qteObject.SetActive(true);
        }
    }
}
