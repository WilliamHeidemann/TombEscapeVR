using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BothEyesChecker : MonoBehaviour
{
    private SolvedIndicator _solvedIndicator;
    private int _eyesLitUp;
    void Start()
    {
        _solvedIndicator = GetComponent<SolvedIndicator>();
    }

    public void EyeLit()
    {
        _eyesLitUp += 1;
        if (_eyesLitUp == 3)
        {
            _solvedIndicator.LightUp();
        }
    }

    public void EyeUnLit()
    {
        _eyesLitUp -= 1;
    }
}
