using System;
using System.Collections;
using System.Collections.Generic;
using StarterAssets;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class PauseMenu : MonoBehaviour
{

    [SerializeField] private Button continueButton;

    [SerializeField] private Button optionsButton;

    [SerializeField] private OptionsMenu optionsMenuPrefab;

    private PlayerInput playerInput;

    private void Awake()
    {
        playerInput = FindObjectOfType<PlayerInput>();
        Pause();
        continueButton.onClick.AddListener(Continue);
        optionsButton.onClick.AddListener(OpenOptions);
        continueButton.Select();
    }

    private void Update()
    {
        if (Input.GetButtonDown("Menu"))
        {
            Continue();
        }
    }

    private void Pause()
    {
        playerInput.currentActionMap = playerInput.actions.FindActionMap("UI");
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    private void Continue()
    {
        playerInput.currentActionMap = playerInput.actions.FindActionMap("Player");
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        Destroy(gameObject);
    }

    private void OpenOptions()
    {
        UiService.Open(optionsMenuPrefab.gameObject);
        Destroy(gameObject);
    }
}
