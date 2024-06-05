using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class ShakingTree : MonoBehaviour
{
    [SerializeField] private Button startButton;

    [SerializeField] private Button backButton;

    [SerializeField] private Slider shakingMeter;

    [SerializeField] private Image controlsScreen;

    [SerializeField] private Image winScreen;

    [SerializeField] private Image loseScreen;

    [SerializeField] private Image finishedScreen;

    [SerializeField] private Button testButton;
    
    private uint _amount = 3;

    public uint addedTimerAmount = 1;

    private float _timer = 4.0f;

    private bool _isRunning;
    
    private void Awake()
    {
        gameObject.SetActive(false);
        //DestroyOldGame();
        startButton.onClick.AddListener(StartGame);
        testButton.onClick.AddListener(AddTimer);
        backButton.onClick.AddListener(CloseGame);
        shakingMeter.interactable = false;
    }

    private void Update()
    {
        shakingMeter.value = _timer;
        
        if (_isRunning)
        {
            _timer -= Time.deltaTime;
        }

        else if (_isRunning && Input.GetKeyDown(KeyCode.E))
        {
            _timer += addedTimerAmount;
        }
    }
    
    public void OpenGame()
    {
        //Animation
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        FindObjectOfType<PlayerInput>().enabled = false;
        
        gameObject.SetActive(value: true);
        shakingMeter.value = _timer;
        finishedScreen.gameObject.SetActive(value: false);
        winScreen.gameObject.SetActive(value: false);
        loseScreen.gameObject.SetActive(value: false);
        Debug.Log(_amount);

        testButton.interactable = false;

        if (_amount > 0)
        {
            startButton.interactable = true;
            controlsScreen.gameObject.SetActive(value: true);
        }

        else if (_amount == 0)
        {
            startButton.interactable = false;
            finishedScreen.gameObject.SetActive(value: true);
        }
    }

    private void CloseGame()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        FindObjectOfType<PlayerInput>().enabled = true;
        gameObject.SetActive(false);
        _isRunning = false;
        _timer = 4.0f;
    }
    
    private void StartGame()
    {
        startButton.interactable = false;
        _isRunning = true;
        
        testButton.interactable = true;
    }

    private void WinGame()
    {
        _isRunning = false;
        controlsScreen.gameObject.SetActive(false);
        winScreen.gameObject.SetActive(true);
        _amount -= 1;
        
        testButton.interactable = false;
    }

    private void LoseGame()
    {
        _isRunning = false;
        controlsScreen.gameObject.SetActive(false);
        loseScreen.gameObject.SetActive(true);
        
        testButton.interactable = false;
    }

    private void AddTimer()
    {
        _timer += addedTimerAmount;
        
        switch (_timer)
        {
            case <= 0:
                LoseGame();
                break;
            case >= 40:
                WinGame();
                break;
        }
    }
}
