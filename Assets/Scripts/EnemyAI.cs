using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float detectionRadius = 5f;
    public LayerMask obstacleLayer;
    public Transform player;

    private Rigidbody rb;
    private bool isPlayerDetected = false;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
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
        }
        else
        {
            rb.velocity = Vector3.zero;
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, detectionRadius);
    }
}
