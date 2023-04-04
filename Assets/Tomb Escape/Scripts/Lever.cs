using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever : MonoBehaviour
{
    [SerializeField] private GameObject anchor;
    [SerializeField] private Animator animator;
    [SerializeField] private SolvedIndicator solvedIndicator;

    private bool _hasBeenPulled;
    private static readonly int Lever1 = Animator.StringToHash("Lever");

    private void OnMouseDown()
    {
        if (_hasBeenPulled) return;
        _hasBeenPulled = true;
        animator.SetTrigger(Lever1);
        solvedIndicator.LightUp();
    }
}
