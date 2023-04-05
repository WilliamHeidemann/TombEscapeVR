using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomTeleporter : MonoBehaviour
{
    private void Awake()
    {
        Fader.MoveRoom += Teleport;
    }

    private void Teleport(Transform room)
    {
        transform.position = room.position;
    }
}
