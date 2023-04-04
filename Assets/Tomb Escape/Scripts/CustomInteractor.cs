using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomInteractor : MonoBehaviour
{
    [SerializeField] OVRInput.Button interactButton;

    void Update()
    {
        Vector3 fwd = transform.TransformDirection(Vector3.forward);
        RaycastHit hit;
        if (Physics.Raycast(transform.position, fwd, out hit))
        {
            if (OVRInput.GetDown(interactButton))
            {
                FindInteractable(hit)?.Interact();
            }
        }
    }

    private IInteractable FindInteractable(RaycastHit hit)
    {
        if(hit.transform.TryGetComponent<IInteractable>(out var interactable))
        {
            return interactable;
        }
        return null;
    }
}
