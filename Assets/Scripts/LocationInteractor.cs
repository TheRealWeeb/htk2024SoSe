using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocationInteractor : MonoBehaviour
{
    private void OnTriggerStay(Collider other)
    {
        if (other.TryGetComponent<IInteractable>(out var interactable) && Input.GetKeyDown(KeyCode.E))
        {
            interactable.Interact();
        }
    }
}
