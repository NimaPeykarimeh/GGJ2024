using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecurityLook : MonoBehaviour
{
    [SerializeField] Transform lookPoint;

    Vector3 lookDirection;
    [SerializeField] float lookDistance;

    public bool lookAround;
    [SerializeField] Transform lookAroundTarget;
    [SerializeField] float lookSpeed = 3;
    
    private void Update()
    {
        lookDirection = (lookPoint.position - transform.position);
        lookDirection.y = 0;
        transform.forward = lookDirection.normalized;


        Vector3 _target;
        if (lookAround)
        {
            _target = lookAroundTarget.position;
        }
        else
        {
            _target = transform.position + (transform.forward * lookDistance);
        }

        lookPoint.position = Vector3.MoveTowards(lookPoint.position, _target, lookSpeed * Time.deltaTime);
    }
}
