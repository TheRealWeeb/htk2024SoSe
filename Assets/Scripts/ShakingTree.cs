using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
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

    private PlayerInput playerInput;
    
    private uint _amount = 3;

    public uint addedTimerAmount = 1;

    private float _timer = 4.0f;

    private bool _isRunning;

    public ItemType type;

    public uint amount;

    private PauseMenu pauseMenu;
    
    private void Awake()
    {
        playerInput = FindObjectOfType<PlayerInput>();
        gameObject.SetActive(false);
        //DestroyOldGame();
        pauseMenu = FindObjectOfType<PauseMenu>();
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

        if (playerInput.actions["Minigame"].WasPressedThisFrame() && _isRunning)
        {
            AddTimer();
        }
        
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
    
    public void OpenGame()
    {
        //Animation
        playerInput.currentActionMap = playerInput.actions.FindActionMap("UI");
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        
        gameObject.SetActive(value: true);
        shakingMeter.value = _timer;
        finishedScreen.gameObject.SetActive(value: false);  
        winScreen.gameObject.SetActive(value: false);
        loseScreen.gameObject.SetActive(value: false);
        Debug.Log(_amount);

        testButton.interactable = false;
        pauseMenu.panelNavigation = 5;

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

    public void CloseGame()
    {
        playerInput.currentActionMap = playerInput.actions.FindActionMap("Player");
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        gameObject.SetActive(false);
        _isRunning = false;
        _timer = 4.0f;
        pauseMenu.panelNavigation = 0;
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
        
        GameState.AddItem(type, amount);
        _timer = 40f;
    }

    private void LoseGame()
    {
        _isRunning = false;
        controlsScreen.gameObject.SetActive(false);
        loseScreen.gameObject.SetActive(true);
        
        testButton.interactable = false;

        _timer = 0f;
    }

    private void AddTimer()
    {
        _timer += addedTimerAmount;
        
        
    }
}
