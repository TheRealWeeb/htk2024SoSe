using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;
using UnityEngine.InputSystem;

public class NextDayTrigger : MonoBehaviour, IInteractable
{
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject teleportTarget;
    [SerializeField] private ItemType requiredItem;
    [SerializeField] private uint requiredAmount;

    private PlayerInput playerInput;

    private void Awake()
    {
        playerInput = FindObjectOfType<PlayerInput>();
    }
    public void Interact()
    {
        if (GameState.TryRemoveItem(requiredItem, requiredAmount))
        {
            StartCoroutine("Teleport");
        }
    }
    
    IEnumerator Teleport()
    {
        playerInput.enabled = false;
        yield return new WaitForSeconds(0.01f);
        player.transform.position = teleportTarget.transform.position;
        yield return new WaitForSeconds(0.01f);
        playerInput.enabled = true;
    }
}
