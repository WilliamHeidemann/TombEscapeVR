using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EyeLight : MonoBehaviour, IPointToInteractable
{
    [SerializeField] private GameObject eyeLight;
    [SerializeField] private BothEyesChecker checker;

    public void Interact()
    {
        eyeLight.SetActive(true);
        checker.EyeLit();
    }

    public void DeActivate()
    {
        eyeLight.SetActive(false);
        checker.EyeUnLit();
    }
}
