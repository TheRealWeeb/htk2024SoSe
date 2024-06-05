using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShakableTree : MonoBehaviour, IInteractable
{
    public void Interact()
    {
        var shakingTree = FindObjectOfType<ShakingTree>(includeInactive: true);
        if (shakingTree.isActiveAndEnabled)
        {
            return;
        }
        
        shakingTree.OpenGame();
    }
}
