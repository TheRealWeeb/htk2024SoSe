using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class HorseTeleport : MonoBehaviour, IInteractable
{
    [SerializeField]
    private GameObject teleportTarget;
    
    [SerializeField]
    private GameObject thePlayer;
    
    public void Interact()
    {
        thePlayer.transform.position = teleportTarget.transform.position;
    }

}
