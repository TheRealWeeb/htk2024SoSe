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

    [SerializeField] private GameObject shakingTree;

    [SerializeField] private GameObject thePlayer;
    
    private ThirdPersonController playerController;

    public int panelNavigation;

    private Fishing fishing;

    private void Awake()
    {
        pausePanel.SetActive(false);
        optionsPanel.SetActive(false);
        continueButton.onClick.AddListener(ClosePauseMenu);
        optionsButton.onClick.AddListener(OpenOptionsMenu);
        backButton.onClick.AddListener(CloseOptionsMenu);
        playerController = thePlayer.GetComponent<ThirdPersonController>();
        fishing = FindObjectOfType<Fishing>(includeInactive: true);
    }
    
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
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
        }
    }
    
    private void OpenPauseMenu()
    {
        pausePanel.SetActive(true);
        
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        playerController.disabled = true;
        
        continueButton.Select();
    }

    private void ClosePauseMenu()
    {
        pausePanel.SetActive(false);

        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        playerController.disabled = false;
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
    }

    
}
