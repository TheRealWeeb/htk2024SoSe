using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class OptionsMenu : MonoBehaviour
{ 
    [SerializeField] private Button closeButton; 
    [SerializeField] private PauseMenu pauseScreen;
    private void Awake()
    {
        closeButton.onClick.AddListener(Close);
        closeButton.Select();
    }

    private void Update() 
    { 
        if (Input.GetButtonDown("Menu")) 
        { 
            Close();
        }
    }
    private void Close() 
    { 
        if (SceneManager.GetActiveScene().buildIndex > 0)
        {
            UiService.Open(pauseScreen.gameObject);
        }
        Destroy(gameObject);
        }
    }
