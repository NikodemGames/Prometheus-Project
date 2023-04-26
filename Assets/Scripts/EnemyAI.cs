using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;

public class EnemyAI : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float detectionRadius = 5f;
    public LayerMask obstacleLayer;
    public Transform player;

    private Rigidbody rb;
    private bool isPlayerDetected = false;
    private Animator animator;
    public GameObject catchQTE;
    //The UI element
    public GameObject QTEPrompt;
    private bool thisone;


    private void OnEnable()
    {
        QTESystem.OnQTEOutcome += HandleQTEOutcome;
    }

    private void OnDisable()
    {
        QTESystem.OnQTEOutcome -= HandleQTEOutcome;
    }

    private void HandleQTEOutcome(bool succeeded)
    {
        if (succeeded&&thisone)
        {
            gameObject.SetActive(false);
            // Execute your logic here for a successful QTE
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            catchQTE.SetActive(true);
            QTEPrompt.SetActive(true);
            thisone= true;

        }
    }
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponentInChildren<Animator>();
    }

    private void FixedUpdate()
    {
        // Check if player is within detection radius
        float distance = Vector3.Distance(player.position, transform.position);
        if (distance <= detectionRadius)
        {
            // Check if player is visible
            RaycastHit hit;
            if (Physics.Raycast(transform.position, player.position - transform.position, out hit, distance, obstacleLayer))
            {
                if (hit.transform != player)
                {
                    isPlayerDetected = false;
                }
                else
                {
                    isPlayerDetected = true;
                }
            }
            else
            {
                isPlayerDetected = true;
            }
        }
        else
        {
            isPlayerDetected = false;
        }

        // Move towards player if detected
        if (isPlayerDetected)
        {
            Vector3 direction = player.position - transform.position;
            rb.velocity = direction.normalized * moveSpeed;
            transform.LookAt(player);
            animator.SetBool("isMoving", true);
        }
        else
        {
            rb.velocity = Vector3.zero;
            animator.SetBool("isMoving", false);

        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, detectionRadius);
    }
}
