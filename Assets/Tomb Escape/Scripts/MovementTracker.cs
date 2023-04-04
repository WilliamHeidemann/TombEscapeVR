using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementTracker : MonoBehaviour
{
    [SerializeField] private Transform thisRoom;
    private bool _trackPlayer;
    //private Transform _playerTransform;
    [SerializeField] private Transform playerHeadset;
    [SerializeField] private Transform rightController;
    [SerializeField] private Transform leftController;
    private Vector3 previousHeadsetPosition;
    private Vector3 previousRightPosition;
    private Vector3 previousLeftPosition;
    private Quaternion previousHeadsetRotation;
    private Quaternion previousRightRotation;
    private Quaternion previousLeftRotation;

    [SerializeField] private HourGlass hourGlass;
    [SerializeField] private float _threshold;
    [SerializeField] private float translationWeight;
    [SerializeField] private float rotationWeight;

    private void Awake()
    {
        Fader.MoveRoom += TrackPlayer;
    }

    private void TrackPlayer(Transform room)
    {
        _trackPlayer = room == thisRoom;
    }

    private void Update()
    {
        if (!_trackPlayer) return;
        var amountMoved = AmountMoved();
        UpdatePreviousPositions();
        if (amountMoved > _threshold)//<>
        {
            hourGlass.FlipHourglass();
        }
    }

    private float AmountMoved()
    {
        float amount = 0;
        //amount += TranslationDifference();
        amount += RotationDifference();
        print("æ" + amount);
        return amount;
    }

    private float RotationDifference()
    {
        float amount = 0;
        amount += Quaternion.Angle(previousHeadsetRotation, playerHeadset.rotation) * rotationWeight;
        amount += Quaternion.Angle(previousRightRotation, rightController.rotation) * rotationWeight;
        amount += Quaternion.Angle(previousLeftRotation, leftController.rotation) * rotationWeight;
        return amount;
    }

    private float TranslationDifference()
    {
        float amount = 0;
        amount += Vector3.Distance(previousHeadsetPosition, playerHeadset.position) * translationWeight;
        amount += Vector3.Distance(previousRightPosition, rightController.position) * translationWeight;
        amount += Vector3.Distance(previousLeftPosition, leftController.position) * translationWeight;
        return amount;
    }

    private void UpdatePreviousPositions()
    {
        previousHeadsetPosition = playerHeadset.position;
        previousRightPosition = rightController.position;
        previousLeftPosition = leftController.position;

        previousHeadsetRotation = playerHeadset.rotation;
        previousRightRotation = rightController.rotation;
        previousLeftRotation = leftController.rotation;
    }

}
