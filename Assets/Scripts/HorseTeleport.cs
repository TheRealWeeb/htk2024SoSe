using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using StarterAssets;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class HorseTeleport : MonoBehaviour, IInteractable
{
    [SerializeField] private GameObject teleportTarget;
    
    [SerializeField] private GameObject thePlayer;

    [SerializeField] private GameObject fade;

    private PlayerInput playerInput;

    private void Start()
    {
        playerInput = thePlayer.GetComponent<PlayerInput>();
    }
    
    public void Interact()
    {
        StartCoroutine("Teleport");

    }

    IEnumerator Teleport()
    {
        playerInput.enabled = false;
        fade.GetComponent<MeshRenderer>().material.DOFade(1, 3f);
        yield return new WaitForSeconds(3f);
        thePlayer.transform.position = teleportTarget.transform.position;
        yield return new WaitForSeconds(1f);
        fade.GetComponent<MeshRenderer>().material.DOFade(0, 3f);
        yield return new WaitForSeconds(3f);
        playerInput.enabled = true;
    }

}
