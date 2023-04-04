using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EyeLight : MonoBehaviour
{
    [SerializeField] private GameObject eyeLight;
    [SerializeField] private BothEyesChecker checker;
    
    private void OnMouseEnter()
    {
        eyeLight.SetActive(true);
        checker.EyeLit();
    }

    private void OnMouseExit()
    {
        eyeLight.SetActive(false);
        checker.EyeUnLit();
    }
}
