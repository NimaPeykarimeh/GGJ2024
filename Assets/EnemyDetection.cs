using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDetection : MonoBehaviour
{
    public Transform player;
    public float detectionRadius = 10f;
    public float detectionAngle = 45f;
    [SerializeField] Material eyeSightMat;

    private void Awake()
    {
        eyeSightMat = transform.Find("nimaguardtriangleplane").GetComponent<MeshRenderer>().material;
    }
    private void Update()
    {
        CheckPlayer();
    }

    void CheckPlayer()
    {
        // Calculate the distance to the player
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        // Check if the player is within the detection radius
        if (distanceToPlayer <= detectionRadius)
        {
            // Calculate the direction to the player
            Vector3 directionToPlayer = Vector3.Normalize(player.position - transform.position);

            // Calculate the dot product between the forward direction of the enemy and the direction to the player
            float dotProduct = Vector3.Dot(transform.forward, directionToPlayer);

            // Calculate the angle in degrees
            float angleToPlayer = Mathf.Acos(dotProduct) * Mathf.Rad2Deg;

            // Check if the player is within the detection angle
            if (angleToPlayer <= detectionAngle * 0.5f)
            {
                // Player is within the detection cone
                Debug.Log("Player Detected!");
                eyeSightMat.color = Color.red;
            }
            else
            {
                eyeSightMat.color = Color.green;
            }
        }
        else
        {
            eyeSightMat.color = Color.green;
        }
    }
}
