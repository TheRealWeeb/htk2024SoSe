using System.Collections;
using System.Collections.Generic;
using Ink.Runtime;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class ConfirmationView : MonoBehaviour
{
    [SerializeField]
    private GameObject confirmationWindow;
    
    [SerializeField]
    private TextMeshProUGUI confirmationText;

    [SerializeField]
    private RectTransform choiceHolder;

    [SerializeField]
    private Button buttonPrefab;

    [SerializeField]
    private string[] action;

    private void Awake()
    {
        confirmationWindow.SetActive(false);
    }

    public void StartConfirmation(TextAsset textAsset)
    {
        FindObjectOfType<PlayerInput>().enabled = false;
        confirmationWindow.SetActive(true);
      
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }
}
