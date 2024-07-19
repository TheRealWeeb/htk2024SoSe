using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using StarterAssets;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using Vector3 = System.Numerics.Vector3;

public class Fishing : MonoBehaviour
{
    [SerializeField] private GameObject inGameCanvas;
    
    [SerializeField] private GameObject thePlayer;
    
    [SerializeField] private GameObject fishingPanel;

    [SerializeField] private Button startButton;

    [SerializeField] private Button catchButton;
    
    [SerializeField] private Button pullButton;

    [SerializeField] private Button tryAgainButton;
    
    [SerializeField] private Slider fishingMeter;
    
    [SerializeField] private Button backButton;

    [SerializeField] private Image guide;
    
    [SerializeField] private Image waitForFish;

    [SerializeField] private Image fishApproaching;
    
    [SerializeField] private Image canCatch;
    
    [SerializeField] private Image doPull;

    [SerializeField] private Image doNotPull;

    [SerializeField] private Image winImage;

    [SerializeField] private Image loseImage;

    private PlayerInput playerInput;

    private Animator animator;

    private float fishSpawnTime;

    private float fishApproachTime;

    private bool isSpawning = false;

    private bool isApproaching = false;

    private bool canFish = false;

    private bool isCatching = false;

    private bool pull = false;

    private bool isPulling = false;

    private float timer = 30f;

    private float addedTimerAmount = 1f;

    private float pullTimer;

    private PauseMenu pauseMenu;

    public ItemType type;

    public uint amount = 4;
    
    private void Awake()
    {
        playerInput = FindObjectOfType<PlayerInput>();
        animator = FindObjectOfType<ThirdPersonController>().GetComponent<Animator>();
        fishingPanel.SetActive(false);
        guide.gameObject.SetActive(false);
        waitForFish.gameObject.SetActive(false);
        fishApproaching.gameObject.SetActive(false);
        canCatch.gameObject.SetActive(false);
        doPull.gameObject.SetActive(false);
        doNotPull.gameObject.SetActive(false);
        winImage.gameObject.SetActive(false);
        loseImage.gameObject.SetActive(false);
        catchButton.gameObject.SetActive(false);
        pullButton.gameObject.SetActive(false);
        tryAgainButton.gameObject.SetActive(false);

        pauseMenu = FindObjectOfType<PauseMenu>();
        
        startButton.onClick.AddListener(FishIncoming);
        catchButton.onClick.AddListener(CatchFish);
        tryAgainButton.onClick.AddListener(FishIncoming);
        backButton.onClick.AddListener(CloseFishing);

        fishingMeter.interactable = false;
    }

    private void Update()
    {
        UpdateTimerAndImage();
        StartPulling();

        fishingMeter.value = timer;
    }

    public void OpenFishing()
    {
        fishingPanel.SetActive(true);
        guide.gameObject.SetActive(true);
        startButton.gameObject.SetActive(true);
        
        playerInput.currentActionMap = playerInput.actions.FindActionMap("UI");
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        animator.SetBool("isFishing", true);
        timer = 30f;

        fishingMeter.value = timer;

        pauseMenu.panelNavigation = 3;
    }

    public void CloseFishing()
    {
        fishingPanel.SetActive(false);
        guide.gameObject.SetActive(false);
        waitForFish.gameObject.SetActive(false);
        fishApproaching.gameObject.SetActive(false);
        canCatch.gameObject.SetActive(false);
        doPull.gameObject.SetActive(false);
        doNotPull.gameObject.SetActive(false);
        winImage.gameObject.SetActive(false);
        loseImage.gameObject.SetActive(false);
        catchButton.gameObject.SetActive(false);
        pullButton.gameObject.SetActive(false);
        tryAgainButton.gameObject.SetActive(false);

        playerInput.currentActionMap = playerInput.actions.FindActionMap("Player");
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.Locked;
        animator.SetBool("isFishing", false);
        animator.SetBool("isBiting", false);
        animator.SetBool("isApproaching", false);
        animator.SetBool("isCatching", false);
        animator.SetBool("fishLost", false);
        animator.SetBool("fishCaught", false);
        //pauseMenu.panelNavigation = 0;
    }

    private void ResetFishing()
    {
        catchButton.gameObject.SetActive(false);
        guide.gameObject.SetActive(false);
        waitForFish.gameObject.SetActive(false);
        fishApproaching.gameObject.SetActive(false);
        canCatch.gameObject.SetActive(false);
        doPull.gameObject.SetActive(false);
        doNotPull.gameObject.SetActive(false);
        winImage.gameObject.SetActive(false);
        catchButton.gameObject.SetActive(false);
        pullButton.gameObject.SetActive(false);
        tryAgainButton.gameObject.SetActive(false);
        loseImage.gameObject.SetActive(true);
        tryAgainButton.gameObject.SetActive(true);
        
        timer = 30f;
        isSpawning = false;
        isApproaching = false;
        canFish = false;
    }
    
    private void FishIncoming()
    {
        startButton.gameObject.SetActive(false);
        tryAgainButton.gameObject.SetActive(false);
        catchButton.gameObject.SetActive(true);
        guide.gameObject.SetActive(false);
        winImage.gameObject.SetActive(false);
        loseImage.gameObject.SetActive(false);
        
        fishSpawnTime = Random.Range(3f, 6f);
        fishApproachTime = Random.Range(3f, 6f);
        isSpawning = true;
    }

    private void UpdateTimerAndImage()
    {
        if (isSpawning)
        {
            fishSpawnTime -= Time.deltaTime;
            guide.gameObject.SetActive(false);
            waitForFish.gameObject.SetActive(true);
        }
        
        if (fishSpawnTime < 0)
        {
            isSpawning = false;
            isApproaching = true;
            animator.SetBool("isApproaching", true);
            fishSpawnTime = 4f;

        }
        
        if (isApproaching)
        {
            fishApproachTime -= Time.deltaTime;
            waitForFish.gameObject.SetActive(false); 
            fishApproaching.gameObject.SetActive(true);
        }
        
        if (fishApproachTime < 0)
        {
            canFish = true;
            animator.SetBool("isBiting", true);
            fishApproaching.gameObject.SetActive(false);
            canCatch.gameObject.SetActive(true);
        }
        
        if (fishApproachTime < -2)
        {
            canFish = false;
            isApproaching = false;
            animator.SetBool("isBiting", false);
            animator.SetBool("fishLost", true);
            ResetFishing();
            canCatch.gameObject.SetActive(false);
            loseImage.gameObject.SetActive(true);
        }

        if (timer < 0)
        {
            LoseGame();
        }

        if (timer > 100)
        {
            WinGame();
        }

        if (pullTimer < 0)
        {
            pullTimer = Random.Range(2f, 4f);
            pull = !pull;
        }

        if (isCatching)
        {
            pullTimer -= Time.deltaTime;
        }

        if (pull && isCatching)
        {
            doPull.gameObject.SetActive(true);
            doNotPull.gameObject.SetActive(false);
        }

        if (!pull && isCatching)
        {
            doPull.gameObject.SetActive(false);
            doNotPull.gameObject.SetActive(true);
        }
    }

    private void CatchFish()
    {
        if (canFish)
        {
            Debug.Log("Caught.");
            StartPulling();
            canFish = false;
            isApproaching = false;
            isCatching = true;
            animator.SetBool("isCatching", true);
            fishApproachTime = 4f;
            
            catchButton.gameObject.SetActive(false);
            pullButton.gameObject.SetActive(true);
            canCatch.gameObject.SetActive(false);
        }

        else
        {
            ResetFishing();
        }
    }

    public void IsPulling()
    {
        isPulling = !isPulling;
    }

    private void LoseGame()
    {
        pullButton.gameObject.SetActive(false);
        tryAgainButton.gameObject.SetActive(true);
        doPull.gameObject.SetActive(false);
        doNotPull.gameObject.SetActive(false);
        loseImage.gameObject.SetActive(true);
        
        isCatching = false;
        isPulling = false;
        animator.SetBool("fishLost", true);
        
        timer = 30f;
    }

    private void WinGame()
    {
        winImage.gameObject.SetActive(true);
        doPull.gameObject.SetActive(false);
        doNotPull.gameObject.SetActive(false);
        pullButton.gameObject.SetActive(false);
        startButton.gameObject.SetActive(true);
        
        timer = 30f;
        
        isCatching = false;
        isPulling = false;
        animator.SetBool("fishCaught", true);

        GameState.AddItem(type, amount);
    }

    private void StartPulling()
    {
        if(isCatching)
        {
            switch (pull)
            {
                case true:
                    switch (isPulling)
                    {
                        case true:
                            timer += addedTimerAmount;
                            break;
                        case false:
                            timer -= Time.deltaTime * 10;
                            break;
                    }

                    break;
                case false:
                    switch (isPulling)
                    {
                        case true:
                            timer -= Time.deltaTime * 20;
                            break;
                        case false:
                            timer -= Time.deltaTime * 10;
                            break;
                    }

                    break;
            }
        }
        else
        {
            return;
        }
    }
}