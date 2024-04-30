using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    [SerializeField]
    private Button continueButton;
    
    [SerializeField]
    private GameObject pausePanel;

    [SerializeField]
    private Button mainMenuButton;

    [SerializeField]
    private int buildIndex;

    [SerializeField]
    private GameObject dialogueMenu;

    private void Awake()
    {
        pausePanel.SetActive(false);
        continueButton.onClick.AddListener(() => SetPausedStatus(false));
        mainMenuButton.onClick.AddListener(MainMenu);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && dialogueMenu.activeSelf == false)
        {
            var wasPreviouslyPaused = pausePanel.activeSelf;
            SetPausedStatus(!wasPreviouslyPaused);
        }
    }

    private void SetPausedStatus(bool isPaused)
    {
        pausePanel.SetActive(isPaused);
        Time.timeScale = isPaused ? 0 : 1;
        Cursor.visible = isPaused;
        Cursor.lockState = isPaused ? CursorLockMode.None : CursorLockMode.Locked;
        FindObjectOfType<PlayerInput>().enabled = !isPaused;
    }

    private void MainMenu()
    {
        SceneManager.LoadScene(buildIndex);
        var wasPreviouslyPaused = pausePanel.activeSelf;
        SetPausedStatus(!wasPreviouslyPaused);
    }
}
