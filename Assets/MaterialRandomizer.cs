using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialRandomizer : MonoBehaviour
{
    [Header("Skin")]
    [SerializeField] Material skinMaterial;
    [SerializeField] Material[] skinOptions;

    [Header("Shirt")]
    [SerializeField] Material ShirtMaterial;
    [SerializeField] Material[] shirtColorOptions;

    [Header("pants")]
    [SerializeField] Material pantMaterial;
    [SerializeField] Material[] pantsOptions;

    void Randimize()
    {
        
    }
}
