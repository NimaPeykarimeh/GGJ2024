using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CustomerPathFinding : MonoBehaviour
{
    [SerializeField] NavMeshAgent agent;
    [SerializeField] Transform securityTransform;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.G)) 
        {
            agent.SetDestination(securityTransform.position);
        }
    }
}
