using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class securityMovement : MonoBehaviour
{
    SecurityLook securityLook;
    Rigidbody rb;

    [SerializeField] float movementSpeed;
    [SerializeField] int currentPointIndex;
    public bool isMoving;
    public Vector3 moveDirection;

    [Header("Points")]
    [SerializeField] Transform[] checkPointArray;
    [SerializeField] int pointCount;
    Transform currentPoint;

    [SerializeField] int direction = 1;
    [SerializeField] float stopDuration = 5f;
    [SerializeField] float stopTimer;
    [SerializeField] float _dis;
    private void Awake()
    {
        securityLook = GetComponent<SecurityLook>();
        pointCount = checkPointArray.Length - 1;
        currentPoint = checkPointArray[currentPointIndex];

        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (isMoving)
        {
            moveDirection = (currentPoint.position - transform.position).normalized;
            moveDirection.y = 0;
            rb.velocity = moveDirection * movementSpeed;
            Vector3 currentPosition = transform.position;
            currentPosition.y = 0;
            _dis = Vector3.Distance(currentPosition, currentPoint.position);
            if (Vector3.Distance(currentPosition, currentPoint.position) <= 1f)
            {
                securityLook.lookAround = true;
                isMoving = false;
            }
        }
        else
        {
            stopTimer -= Time.deltaTime;
            rb.velocity = Vector3.zero;
            if (stopTimer < 0) 
            {
                SwitchPoint();
            }
        }


    }

    void SwitchPoint()
    {
        currentPointIndex += direction;

        if (currentPointIndex < 0)
        {
            currentPointIndex = 1;
            direction *= -1;
        }
        else if (currentPointIndex >= pointCount) 
        {
            currentPointIndex = pointCount;
            direction *= -1;
        }
        currentPoint = checkPointArray[currentPointIndex];
        securityLook.lookAround = false;
        isMoving = true;
        stopTimer = stopDuration;

    }

}
