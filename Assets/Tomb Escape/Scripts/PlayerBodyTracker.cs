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
    private Vector3 _distanceVector;
    private void Awake()
    {
        Fader.MoveRoom += (room) => _isTracking = room == roomToTrack; //<>
    }
    
    private void Update()
    {
        if (!_isTracking) return;
        _distanceBetweenHands = Vector3.Distance(rightHand.position, leftHand.position);
        if (_distanceBetweenHands == 0) return; // One controller not detected
        _distanceVector = rightHand.position - leftHand.position;
        // Flip x and z because the world is in another direction
        _distanceVector = new Vector3(_distanceVector.z, _distanceVector.y, -_distanceVector.x);
        print("æ " + _distanceVector);
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
        if (_distanceVector.x < 4) return false;
        if (_distanceVector.y < 4) return false;
        if (Mathf.Abs(_distanceVector.z) > 4) return false;
        return true;
    }
    private bool IsPoseTwo()
    {
        if (_distanceVector.x < 6) return false;
        if (Mathf.Abs(_distanceVector.y) > 4) return false;
        if (Mathf.Abs(_distanceVector.z) > 4) return false;
        return true;
    }
    private bool IsPoseThree()
    {
        if (_distanceVector.x < 4) return false;
        if (_distanceVector.y > -4) return false;
        if (_distanceVector.z < 4) return false;
        return true;
    }
}
