using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementTracker : MonoBehaviour
{
    [SerializeField] private Transform thisRoom;
    private bool _trackPlayer;
    private Transform _playerTransform;
    [SerializeField] private HourGlass hourGlass;

    private void Awake()
    {
        Fader.MoveRoom += TrackPlayer;
        _playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void TrackPlayer(Transform room)
    {
        _trackPlayer = room == thisRoom;
    }

    private void Update()
    {
        if (!_trackPlayer) return;
        if (!_playerTransform.hasChanged) return;
        _playerTransform.hasChanged = false;
        hourGlass.FlipHourglass();
    }
}
