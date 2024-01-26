using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointMove : MonoBehaviour
{

    [SerializeField] float rotationSpeed;
    [SerializeField] Vector3 rotationDirection;

    private void Update()
    {
        transform.Rotate(rotationDirection * Time.deltaTime);
    }



}
