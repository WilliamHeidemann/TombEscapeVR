using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour, IInteractable
{
    public delegate void MoveRoomDelegate(Transform room);
    public static event MoveRoomDelegate StartFade;
    [SerializeField] private Transform roomOne;
    [SerializeField] private Transform roomTwo;
    
    private Transform NextRoom() => CurrentRoom.Instance.Current == roomOne ? roomTwo : roomOne;

    private void OnMouseDown()
    {
        var next = NextRoom();
        StartFade?.Invoke(next);
    }

    public void Interact()
    {
        print("Opening door!");
        //var next = NextRoom();
        //StartFade?.Invoke(next);
    }
}
