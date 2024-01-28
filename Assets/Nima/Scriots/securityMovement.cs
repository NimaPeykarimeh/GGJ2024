using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class securityMovement : MonoBehaviour
{
    SecurityLook securityLook;
    Animator animator;
    Rigidbody rb;

    [SerializeField] float movementSpeed;
    [SerializeField] int currentPointIndex;
    public bool isMoving;
    public Vector3 moveDirection;

    [Header("Points")]
     Transform checkPointParent;
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
        animator = GetComponent<Animator>();

        rb = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        checkPointParent = transform.parent.Find("CheckPoints");
        GetTheCheckPoints();
        currentPoint = checkPointArray[currentPointIndex];

    }

    void GetTheCheckPoints()//get the list of the check point by the childs of the parent
    {
        checkPointArray = new Transform[checkPointParent.childCount];
        for (int i = 0; i < checkPointArray.Length; i++)
        {
            checkPointArray[i] = checkPointParent.GetChild(i);
        }
        pointCount = checkPointArray.Length - 1;
    }

    private void Update()
    {
        animator.SetFloat("Velocity", rb.velocity.magnitude);
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
