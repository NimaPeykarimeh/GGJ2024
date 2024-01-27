using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movementController : MonoBehaviour
{
    Laugher laugher;
    [SerializeField] float movementSpeed;
    Vector3 moveDirection;

    Rigidbody playerRb;
    public bool canMove;

    private void Awake()
    {
        laugher = GetComponent<Laugher>();
        playerRb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        moveDirection.x = Input.GetAxis("Horizontal");
        moveDirection.z = Input.GetAxis("Vertical");
        if (canMove)
        {
            playerRb.velocity = moveDirection * movementSpeed;

            if (moveDirection.magnitude > 0)
            {
                if (laugher.isPranking)
                {
                    laugher.startLaugher(false);
                }
                transform.forward = moveDirection.normalized;
            }
        }
    }
}
