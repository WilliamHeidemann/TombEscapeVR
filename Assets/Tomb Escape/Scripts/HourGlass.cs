using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HourGlass : MonoBehaviour
{
    [SerializeField] private Transform thisRoom;
    private bool _ticking;
    [SerializeField] private float solvedCountDownStart; // Change in inspector
    private float _solvedCountDown;
    [SerializeField] private Animator animator;
    [SerializeField] private SolvedIndicator solvedIndicator;
    private static readonly int Flip = Animator.StringToHash("Flip");
    private bool _canBeFlippedAgain;
    private float _cooldownFlip;

    private void Awake()
    {
        Fader.MoveRoom += ToggleTimer;
    }

    private void ToggleTimer(Transform room)
    {
        _ticking = room == thisRoom;
        _solvedCountDown = solvedCountDownStart;
    }

    private void Update()
    {
        if (!_ticking) return;
        _solvedCountDown -= Time.deltaTime;
        CooldownFlip();
        if (_solvedCountDown <= 0)
        {
            solvedIndicator.LightUp();
            //Destroy(this);
        }
    }

    private void CooldownFlip()
    {
        _cooldownFlip -= Time.deltaTime;
        _canBeFlippedAgain = _cooldownFlip <= 0f;
    }

    public void FlipHourglass()
    {
        if (_canBeFlippedAgain)
        {
            _solvedCountDown = solvedCountDownStart;
            _cooldownFlip = 1f;
            animator.SetTrigger(Flip);
        }
    }
}
