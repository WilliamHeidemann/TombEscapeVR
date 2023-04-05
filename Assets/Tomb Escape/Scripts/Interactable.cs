using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IClickInteractable
{
    public void Interact();
}

public interface IPointToInteractable
{
    public void OnPointedAt();
    public void OnStoppedPointingAt();
}