using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class HorseTeleport : MonoBehaviour, IInteractable
{
    [SerializeField] private Transform teleportTarget;
    
    [SerializeField] private Transform thePlayer;
    
    public void Interact()
    {
        thePlayer.position = teleportTarget.position;
    }

}
