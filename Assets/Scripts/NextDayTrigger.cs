using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using DG.Tweening;
using UnityEngine;
using UnityEngine.InputSystem;

public class NextDayTrigger : MonoBehaviour, IInteractable
{
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject teleportTarget;
    [SerializeField] private ItemType requiredItem;
    [SerializeField] private uint requiredAmount;
    [SerializeField] private GameObject fade;

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
        fade.GetComponent<MeshRenderer>().material.DOFade(1, 3f);
        yield return new WaitForSeconds(3f);
        player.transform.position = teleportTarget.transform.position;
        yield return new WaitForSeconds(1f);
        fade.GetComponent<MeshRenderer>().material.DOFade(0, 3f);
        yield return new WaitForSeconds(3f);
        playerInput.enabled = true;
    }
}
