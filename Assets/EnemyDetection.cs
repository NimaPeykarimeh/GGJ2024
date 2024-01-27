using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDetection : MonoBehaviour
{
    Laugher laugher;
    GameManager gameManager;
    public Transform player;
    public float detectionRadius = 10f;
    public float detectionAngle = 45f;
    [SerializeField] Material eyeSightMat;
    [SerializeField] bool isAlerted = false;

    private void Awake()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        eyeSightMat = transform.Find("nimaguardtriangleplane").GetComponent<MeshRenderer>().material;
        player = GameObject.FindGameObjectWithTag("Player").transform;
        laugher = player.GetComponent<Laugher>();
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
                if (!isAlerted && laugher.isPranking)
                {
                    isAlerted=true;
                    gameManager.TimeOver();
                    
                }
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
