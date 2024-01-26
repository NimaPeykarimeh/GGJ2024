using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class securityMovement : MonoBehaviour
{
    SecurityLook securityLook;

    [SerializeField] float movementSpeed;
    [SerializeField] int currentPointIndex;

    [Header("Points")]
    [SerializeField] Transform[] checkPointArray;
    Transform currentPoint;

    int pointCount;
    int direction = 1;
    [SerializeField] float stopDuration = 5f;

    private void Awake()
    {
        securityLook = GetComponent<SecurityLook>();
        pointCount = checkPointArray.Length - 1;
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
            currentPointIndex = pointCount - 1;
            direction *= -1;
        }


    }

}
