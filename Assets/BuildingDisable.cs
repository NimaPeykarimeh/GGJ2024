using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingDisable : MonoBehaviour
{
    [SerializeField] GameObject Building;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Building.SetActive(false);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Building.SetActive(true);
        }
    }
}
