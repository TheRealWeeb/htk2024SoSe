using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CloseableView : MonoBehaviour
{
    private PlayerInput playerInput;

    private void Awake()
    {
        playerInput = FindObjectOfType<PlayerInput>();
    }

    private void Update()
    {
        if (playerInput.actions["Cancel"].WasPressedThisFrame())
        {
            Destroy(gameObject);
        }
    }
}


