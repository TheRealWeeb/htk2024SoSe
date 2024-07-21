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
    [SerializeField] private GameObject pausePanel;

    [SerializeField] private GameObject optionsPanel;

    [SerializeField] private Button continueButton;

    [SerializeField] private Button optionsButton;

    [SerializeField] private Button backButton;

    [SerializeField] private int buildIndex;

    [SerializeField] private GameObject dialogueMenu;

    [SerializeField] private GameObject thePlayer;

    private PlayerInput playerInput;

    public int panelNavigation;

    private Fishing fishing;

    private StoryView storyView;

    private ShakingTree shakingTree;

    private void Awake()
    {
        pausePanel.SetActive(false);
        optionsPanel.SetActive(false);
        continueButton.onClick.AddListener(ClosePauseMenu);
        optionsButton.onClick.AddListener(OpenOptionsMenu);
        backButton.onClick.AddListener(CloseOptionsMenu);
        playerInput = FindObjectOfType<PlayerInput>();
        fishing = FindObjectOfType<Fishing>(includeInactive: true);
        storyView = FindObjectOfType<StoryView>(includeInactive: true);
    }

    private void Update()
    {
        if (playerInput.actions["Pause"].WasPressedThisFrame() || playerInput.actions["Exit"].WasPressedThisFrame())
        {
            PanelNavigation();
        }
    }

    private void PanelNavigation()
    {
        switch (panelNavigation)
        {
            case 0:
                OpenPauseMenu();
                panelNavigation = 1;
                break;
            case 1:
                ClosePauseMenu();
                panelNavigation = 0;
                break;
            case 2:
                CloseOptionsMenu();
                panelNavigation = 1;
                break;
            case 3:
                fishing.CloseFishing();
                panelNavigation = 0;
                break;
            case 4:
                storyView.CloseStory();
                panelNavigation = 0;
                break;
            case 5:
                shakingTree.CloseGame();
                panelNavigation = 0;
                break;
        }
    }

    private void OpenPauseMenu()
    {
        pausePanel.SetActive(true);

        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        playerInput.currentActionMap = playerInput.actions.FindActionMap("UI");

        continueButton.Select();
    }

    private void ClosePauseMenu()
    {
        pausePanel.SetActive(false);

        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        playerInput.currentActionMap = playerInput.actions.FindActionMap("Player");
        panelNavigation = 0;
    }

    private void OpenOptionsMenu()
    {
        pausePanel.SetActive(false);
        optionsPanel.SetActive(true);

        panelNavigation = 2;
    }

    private void CloseOptionsMenu()
    {
        optionsPanel.SetActive(false);
        pausePanel.SetActive(true);

        continueButton.Select();
        panelNavigation = 1;
    }

}