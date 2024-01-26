using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] Transform playerTransform;
    [SerializeField] float followSpeed = 0.125f;
    [SerializeField] Vector3 offset;
    private void FixedUpdate()
    {
        transform.position = Vector3.Lerp(transform.position,playerTransform.position + offset,followSpeed);
    }
}
