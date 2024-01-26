using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movementController : MonoBehaviour
{
    [SerializeField] float movementSpeed;
    Vector3 moveDirection;

    Rigidbody playerRb;

    private void Awake()
    {
        playerRb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        moveDirection.x = Input.GetAxis("Horizontal");
        moveDirection.z = Input.GetAxis("Vertical");
        playerRb.velocity = moveDirection * movementSpeed;

        if (moveDirection.magnitude > 0)
        {
            transform.forward = moveDirection.normalized;
        }
    }
}
