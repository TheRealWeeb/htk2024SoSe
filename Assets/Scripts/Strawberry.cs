using System.Collections;
using System.Collections.Generic;
using System.Timers;
using DefaultNamespace;
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
    [SerializeField] private GameObject strawberrySeed;
    [SerializeField] private GameObject wateredStrawberrySeed;
    [SerializeField] private GameObject grownStrawberry;

    private PlayerInput playerInput;
    
    private Animator animator;
    
    private float timer = 2f;

    private bool isWatered = false;

    private bool isPlanted = false;

    private void Awake()
    {
        playerInput = FindObjectOfType<PlayerInput>();
        animator = FindObjectOfType<ThirdPersonController>().GetComponent<Animator>();
        wateringCan.SetActive(false);
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
                gameObject.GetComponent<Collider>().enabled = false;
                StartCoroutine("IsWatering");
                isWatered = true;
                QuestSystem.UpdateQuests();
            }
        }
        else if (isPlanted && isWatered)
        {
            if (GameState.HasEnoughItems(requiredItemThree, requiredAmountThree))
            {
                GameState.AddItem(reward, amount);
            }
        }
    }

    IEnumerator IsPlanting()
    {
        playerInput.enabled = false;
        animator.SetBool("isPlanting", true);
        yield return new WaitForSeconds(3.125f);
        playerInput.enabled = true;
        animator.SetBool("isPlanting", false);
        strawberrySeed.SetActive(true);
    }

    IEnumerator IsWatering()
    {
        playerInput.enabled = false;
        animator.SetBool("isWatering", true);
        wateringCan.SetActive(true);
        yield return new WaitForSeconds(3.167f);
        playerInput.enabled = true;
        animator.SetBool("isWatering", false);
        wateringCan.SetActive(false);
        strawberrySeed.SetActive(false);
        wateredStrawberrySeed.SetActive(true);
    }
}
