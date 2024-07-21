using System.Collections;
using System.Collections.Generic;
using System.Timers;
using DefaultNamespace;
using FMODUnity;
using StarterAssets;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Strawberry : MonoBehaviour, IInteractable
{
    [SerializeField] private GameObject wateringCan;
    [SerializeField] private ItemType requiredItem;
    [SerializeField] private uint requiredAmount;
    [SerializeField] private ItemType reward;
    [SerializeField] private uint amount;
    [SerializeField] private ItemType requiredItemTwo;
    [SerializeField] private uint requiredAmountTwo;
    [SerializeField] private ItemType requiredItemThree;
    [SerializeField] private uint requiredAmountThree;
    [SerializeField] private ItemType requiredItemFour;
    [SerializeField] private uint requiredAmountFour;
    [SerializeField] private ItemType rewardTwo;
    [SerializeField] private uint amountTwo;
    [SerializeField] private GameObject strawberrySeed;
    [SerializeField] private GameObject wateredStrawberrySeed;
    [SerializeField] private GameObject strawberryStem;
    [SerializeField] private GameObject wateredStrawberryStem;
    [SerializeField] private GameObject grownStrawberry;
    [SerializeField] private EventReference plantingSound;
    [SerializeField] private EventReference wateringSound;
    [SerializeField] private EventReference pickUpSound;
    
    private PlayerInput playerInput;
    
    private Animator animator;
    
    private float timer = 2f;

    private bool isWatered = false;

    private bool isPlanted = false;

    private bool isWateredAgain = false;

    private bool isHarvested = false;

    private void Awake()
    {
        playerInput = FindObjectOfType<PlayerInput>();
        animator = FindObjectOfType<ThirdPersonController>().GetComponent<Animator>();
        wateringCan.SetActive(false);
        strawberrySeed.SetActive(false);
        wateredStrawberrySeed.SetActive(false);
        strawberryStem.SetActive(false);
        wateredStrawberrySeed.SetActive(false);
        grownStrawberry.SetActive(false);
    }

    
    public void Interact()
    {
        if (!isPlanted)
        {
            if (GameState.TryRemoveItem(requiredItem, requiredAmount))
            {
                isPlanted = true;
                GameState.AddItem(reward, amount);
                StartCoroutine("IsPlanting");
            }
        }
        else if (isPlanted && isWatered == false)
        {
            if (GameState.HasEnoughItems(requiredItemTwo, requiredAmountTwo))
            {
                GameState.AddItem(reward, amount);
                StartCoroutine("IsWatering");
                isWatered = true;
                QuestSystem.UpdateQuests();
            }
        }
        else if (isPlanted && isWatered && isWateredAgain == false)
        {
            if (GameState.HasEnoughItems(requiredItemThree, requiredAmountThree))
            {
                GameState.AddItem(reward, amount);
                StartCoroutine("IsWateringAgain");
                isWateredAgain = true;
                QuestSystem.UpdateQuests();
            }
        }
        else if (isHarvested == false && isWateredAgain == true)
        {
            if (GameState.HasEnoughItems(requiredItemFour, requiredAmountFour))
            {
                GameState.AddItem(rewardTwo, amountTwo);
                StartCoroutine("IsHarvesting");
                isHarvested = true;
                QuestSystem.UpdateQuests();
            }
        }
    }

    IEnumerator IsPlanting()
    {
        playerInput.enabled = false;
        animator.SetBool("isPlanting", true);
        AudioManager.instance.PlayOneShot(plantingSound, transform.position);
        yield return new WaitForSeconds(3.125f);
        playerInput.enabled = true;
        animator.SetBool("isPlanting", false);
        strawberrySeed.SetActive(true);
    }

    IEnumerator IsWatering()
    {
        playerInput.enabled = false;
        animator.SetBool("isWatering", true);
        AudioManager.instance.PlayOneShot(wateringSound, transform.position);
        wateringCan.SetActive(true);
        yield return new WaitForSeconds(3.167f);
        playerInput.enabled = true;
        animator.SetBool("isWatering", false);
        wateringCan.SetActive(false);
        strawberrySeed.SetActive(false);
        wateredStrawberrySeed.SetActive(true);
    }

    IEnumerator IsWateringAgain()
    {
        playerInput.enabled = false;
        animator.SetBool("isWatering", true);
        AudioManager.instance.PlayOneShot(wateringSound, transform.position);
        wateringCan.SetActive(true);
        yield return new WaitForSeconds(3.167f);
        playerInput.enabled = true;
        animator.SetBool("isWatering", false);
        wateringCan.SetActive(false);
        strawberryStem.SetActive(false);
        wateredStrawberryStem.SetActive(true);
    }

    IEnumerator IsHarvesting()
    {
        playerInput.enabled = false;
        animator.SetBool("isPickingUp", true);
        AudioManager.instance.PlayOneShot(pickUpSound, transform.position);
        yield return new WaitForSeconds(1.333f);
        playerInput.enabled = true;
        animator.SetBool("isPickingUp", false);
        grownStrawberry.SetActive(false);
    }
}
