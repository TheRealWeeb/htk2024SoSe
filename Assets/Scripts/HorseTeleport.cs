using System.Collections;
using System.Collections.Generic;
using StarterAssets;
using Unity.VisualScripting;
using UnityEngine;

public class HorseTeleport : MonoBehaviour, IInteractable
{
    [SerializeField] private GameObject teleportTarget;
    
    [SerializeField] private GameObject thePlayer;

    private ThirdPersonController playerController;

    private void Start()
    {
        playerController = thePlayer.GetComponent<ThirdPersonController>();
    }
    
    public void Interact()
    {
        StartCoroutine("Teleport");

    }

    IEnumerator Teleport()
    {
        playerController.disabled = true;
        yield return new WaitForSeconds(0.01f);
        thePlayer.transform.position = teleportTarget.transform.position;
        yield return new WaitForSeconds(0.01f);
        playerController.disabled = false;
    }

}
