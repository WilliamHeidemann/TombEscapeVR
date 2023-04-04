using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SolvedIndicator : MonoBehaviour
{
    [SerializeField] private Material solvedMaterial;
    private MeshRenderer _meshRenderer;

    private void Start()
    {
        _meshRenderer = GetComponent<MeshRenderer>();
    }

    public void LightUp()
    {
        _meshRenderer.material = solvedMaterial;
    }
}
