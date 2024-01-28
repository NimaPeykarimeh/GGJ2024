using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishGame : MonoBehaviour
{
    Rigidbody body;
    Transform player;
    [SerializeField] Transform sitPosition;
    CameraFollow cameraFollow;
    [SerializeField] Vector3 farOffset;

    [SerializeField] float maxSpeed = 5;
    [SerializeField] float currentSpeed = 0;
    [SerializeField] float accelaration = 2;
    bool isRiding;

    AudioSource audioSource;
    [SerializeField] AudioClip carSound;

    [SerializeField] GameObject decal1;
    [SerializeField] GameObject decal2;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        cameraFollow = FindAnyObjectByType<CameraFollow>();
        body = GetComponent<Rigidbody>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void Update()
    {
        if (isRiding)
        {
            currentSpeed = Mathf.MoveTowards(currentSpeed, maxSpeed,accelaration * Time.deltaTime);
            body.velocity = -transform.right * currentSpeed;
        }
        if (Input.GetKeyDown(KeyCode.C) && !isRiding)
        {
            RideTheTruck();
        }
    }

    void RideTheTruck()
    {
        decal1.SetActive(false);
        decal2.SetActive(false);
        player.GetComponent<Rigidbody>().isKinematic = true;
        player.GetComponent<Collider>().isTrigger = true;
        player.transform.parent = sitPosition.transform;
        player.position = sitPosition.position;
        cameraFollow.offset = farOffset;
        audioSource.PlayOneShot(carSound);
        isRiding = true;
        currentSpeed = 0;
    }
}
