using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PendulumReactor : MonoBehaviour
{
    [SerializeField] private Transform pendulum;
    [SerializeField] private Material lit;
    [SerializeField] private Material unlit;
    [SerializeField] private MeshRenderer plateOne;
    [SerializeField] private MeshRenderer plateTwo;
    [SerializeField] private MeshRenderer plateThree;
    [SerializeField] private SolvedIndicator solvedIndicator;
    private int _amountActivated;
    
    private void OnMouseDown()
    {
        var rotation = pendulum.localRotation.eulerAngles.z;
        if (rotation is < 10f or > 350f)
        {
            Activate();
        }
        else
        {
            Reset();
        }
    }

    private void Reset()
    {
        _amountActivated = 0;
        plateOne.material = unlit;
        plateTwo.material = unlit;
        plateThree.material = unlit;
    }

    private void Activate()
    {
        switch (_amountActivated)
        {
            case 0:
                plateOne.material = lit;
                break;
            case 1:
                plateTwo.material = lit;
                break;
            case 2:
                plateThree.material = lit;
                Solved();
                break;
        }

        _amountActivated += 1;
    }

    private void Solved()
    {
        solvedIndicator.LightUp();
    }
}
