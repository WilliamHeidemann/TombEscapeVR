using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBodyTracker : MonoBehaviour
{
    [SerializeField] private Transform roomToTrack;
    [SerializeField] private SolvedIndicator solvedIndicator;
    [SerializeField] private Transform rightHand;
    [SerializeField] private Transform leftHand;
    [SerializeField] private Material solvedPositionMaterial;
    [SerializeField] private MeshRenderer solvedPositionOneIndicator;
    [SerializeField] private MeshRenderer solvedPositionTwoIndicator;
    [SerializeField] private MeshRenderer solvedPositionThreeIndicator;
    
    private bool _isTracking;
    private bool _firstPositionDone;
    private bool _secondPositionDone;
    private bool _thirdPositionDone;

    private float _distanceBetweenHands;
    private void Awake()
    {
        Fader.MoveRoom += (room) => _isTracking = room == roomToTrack; //<>
    }

    private void Update()
    {
        if (!_isTracking) return;
        _distanceBetweenHands = Vector3.Distance(rightHand.position, leftHand.position);
        if (_distanceBetweenHands == 0) return; // One controller not detected
        if (_distanceBetweenHands < 8) return; // Hands too close
        if (IsPoseOne())
        {
            _firstPositionDone = true;
            solvedPositionOneIndicator.material = solvedPositionMaterial;
        }
        if (IsPoseTwo())
        {
            _firstPositionDone = true;
            solvedPositionTwoIndicator.material = solvedPositionMaterial;
        }
        if (IsPoseThree())
        {
            _firstPositionDone = true;
            solvedPositionThreeIndicator.material = solvedPositionMaterial;
        }

        if (_firstPositionDone && _secondPositionDone && _thirdPositionDone)
        {
            solvedIndicator.LightUp();
            Destroy(this);
        }
    }

    private bool IsPoseOne()
    {
        var distanceVector =  rightHand.position - leftHand.position;
        if (distanceVector.x < 4) return false;
        if (distanceVector.y < 4) return false;
        return true;
    }
    private bool IsPoseTwo()
    {
        var angleDifference = Quaternion.Angle(rightHand.rotation, leftHand.rotation);
        return angleDifference > 170f;
    }
    private bool IsPoseThree()
    {
        var distanceVector =  rightHand.position - leftHand.position;
        if (distanceVector.x > -4) return false;
        if (distanceVector.z < 4) return false;
        return true;
    }
}
