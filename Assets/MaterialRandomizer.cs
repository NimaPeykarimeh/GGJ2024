using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialRandomizer : MonoBehaviour
{
    [Header("Skin")]
    [SerializeField] Material skinMaterial;
    [SerializeField] Color[] skinOptions;

    [Header("Shirt")]
    [SerializeField] Material ShirtMaterial;
    [SerializeField] Material Shirt2Material;
    [SerializeField] Color[] shirtColorOptions;

    [Header("pants")]
    [SerializeField] Material pantMaterial;
    [SerializeField] Color[] pantsOptions;

    MeshRenderer meshRenderer;

    private void Awake()
    {
        meshRenderer = GetComponent<MeshRenderer>();
    }

    private void Start()
    {
        skinMaterial = meshRenderer.materials[0];
        pantMaterial = meshRenderer.materials[1];
        ShirtMaterial = meshRenderer.materials[2];
        Shirt2Material = meshRenderer.materials[3];
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            Randomize();
        }
    }

    Color Choose(Color[] matList)
    {
        int _rand = Random.Range(0, matList.Length - 1);
        return matList[_rand]; 
    }

    void Randomize()
    {
        skinMaterial.color = Choose(skinOptions);
    }
}
