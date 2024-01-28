using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;

public class EnemyDetection : MonoBehaviour
{
    MoneyCollect moneyCollect;
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
        moneyCollect = player.GetComponent<MoneyCollect>();
    }
    private void Update()
    {
        CheckPlayer();
    }

    bool CheckThePlayerRay()
    {
        
        Ray ray = new Ray(transform.position, player.position - transform.position);

        
        float maxDistance = Vector3.Distance(transform.position, player.position) + 5;

        
        RaycastHit hit;

        
        if (Physics.Raycast(ray, out hit, maxDistance))
        {
        
            Debug.Log("Hit object: " + hit.collider.gameObject.name);
            if (hit.collider.CompareTag("Player"))
            {
                Debug.Log("PLAYERRRR");
                return true;
            }
            Debug.Log("Otherrrr");
            return false;
        
        }
        else
        {
            Debug.Log("Ray did not hit anything.");
        }
        return false;
    }

    void CheckPlayer()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        if (distanceToPlayer <= detectionRadius)
        {
            Vector3 directionToPlayer = Vector3.Normalize(player.position - transform.position);

            float dotProduct = Vector3.Dot(transform.forward, directionToPlayer);
       
            float angleToPlayer = Mathf.Acos(dotProduct) * Mathf.Rad2Deg;

            if (angleToPlayer <= detectionAngle * 0.5f)
            {
                
                if (!isAlerted && (laugher.isPranking || moneyCollect.isGrabing) && CheckThePlayerRay())
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
