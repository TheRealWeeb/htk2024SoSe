using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using JetBrains.Annotations;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private PlayerInputActions playerInputActions;

    [CanBeNull] private IInteractable? _currentInteractable;

    private void Awake()
    {
        playerInputActions = new PlayerInputActions();
    }
    
    private void OnEnable()
    {
        playerInputActions.Player.Interact.Enable();
        playerInputActions.Player.Interact.started += DoInteract;
    }

    private void OnDisable()
    {
        playerInputActions.Player.Interact.started -= DoInteract;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<IInteractable>(out var interactable))
        {
            _currentInteractable = interactable;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent<IInteractable>(out var interactable))
        {
            if (_currentInteractable == interactable)
            {
                _currentInteractable = null;
            }
        }
    }

    private void DoInteract(InputAction.CallbackContext obj)
    {
        _currentInteractable?.Interact();

        if (_currentInteractable != null)
        {
            playerInputActions.Player.Move.Disable();
            playerInputActions.Player.Look.Disable();
        }
    }
}
