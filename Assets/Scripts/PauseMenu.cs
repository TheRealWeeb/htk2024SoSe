using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    [SerializeField]
    private Button continueButton;
    
    [SerializeField]
    private GameObject pausePanel;

    private void Awake()
    {
        pausePanel.SetActive(false);
        continueButton.onClick.AddListener(() => SetPausedStatus(false));
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
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
    }
}
