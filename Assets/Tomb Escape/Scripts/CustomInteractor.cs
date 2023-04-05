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
            if (hit.collider.CompareTag("ClickInteractable"))
            {
                if (OVRInput.GetDown(interactButton))
                {
                    hit.collider.GetComponent<IClickInteractable>().Interact();
                }
            }

            if (hit.collider.CompareTag("PointToInteractable"))
            {
                hit.collider.GetComponent<IPointToInteractable>().Interact();
            }
        }
    }

    private IClickInteractable FindInteractable(RaycastHit hit)
    {
        if (hit.collider.TryGetComponent<IClickInteractable>(out var interactable))
        {
            return interactable;
        }
        return null;
    }
}
