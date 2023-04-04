using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrentRoom : MonoBehaviour
{
    [SerializeField] private Transform startingRoom;
    public Transform Current { get; set; }
    public static CurrentRoom Instance;
    
    private void Awake()
    {
        if (Instance != null) Destroy(this);
        Instance = this;

        Fader.MoveRoom += room => Current = room;
    }

    private void Start() => Current = startingRoom;
}
