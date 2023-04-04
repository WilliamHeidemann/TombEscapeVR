using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class KeyboardMovement : MonoBehaviour
{
    [SerializeField] private float movementSpeed;
    private CharacterController _controller;

    private void Awake()
    {
        _controller = GetComponent<CharacterController>();
        Fader.MoveRoom += Teleport;
    }

    private void Update()
    {
        Movement();
    }

    private void Movement()
    {
        var direction = Input.GetAxisRaw("Horizontal") * transform.right + Input.GetAxisRaw("Vertical") * transform.forward;
        direction = direction.normalized;
        _controller.Move(movementSpeed * Time.deltaTime * direction);
    }
    
    private void Teleport(Transform room)
    {
        _controller.enabled = false;
        transform.position = room.position;
        _controller.enabled = true;
    }
}
