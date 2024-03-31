using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

interface Interactable
{
    public void Interact();
}
public class Interact : MonoBehaviour
{
    public Transform InteractSource;
    public float InteractRange;

    void OnInteract()
    {
        Ray ray = new Ray(InteractSource.position, InteractSource.forward);
        if (Physics.Raycast(ray, out RaycastHit hitInfo, InteractRange))
        {
            if (hitInfo.collider.gameObject.TryGetComponent(out Interactable interactObj))
            {
                interactObj.Interact();
            }
        }
    }
}
