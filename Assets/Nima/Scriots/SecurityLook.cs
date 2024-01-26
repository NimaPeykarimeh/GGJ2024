using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecurityLook : MonoBehaviour
{
    securityMovement securityMovement;

    [SerializeField] Transform lookPoint;

    Vector3 lookDirection;
    [SerializeField] float lookDistance;

    public bool lookAround;
    [SerializeField] Transform lookAroundTarget;
    [SerializeField] float lookSpeed = 3;
    [SerializeField] float lookSpeed2 = 3;

    private void Awake()
    {
        securityMovement = GetComponent<securityMovement>();
    }

    private void Update()
    {
        lookDirection = (lookPoint.position - transform.position);
        lookDirection.y = 0;
        transform.forward = lookDirection.normalized;


        Vector3 _target;
        if (!securityMovement.isMoving)
        {
            _target = lookAroundTarget.position;
            lookPoint.position = Vector3.MoveTowards(lookPoint.position, _target, lookSpeed2 * Time.deltaTime);
        }
        else
        {
            _target = transform.position + (securityMovement.moveDirection * lookDistance);
            lookPoint.position = Vector3.Lerp(lookPoint.position, _target, lookSpeed);
        }


        
    }
}
