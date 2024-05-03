using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConfirmationObject : MonoBehaviour, IInteractable
{
    [SerializeField]
    private TextAsset confirmation;
    
    public void Interact()
    {
        var confirmationMsg = FindObjectOfType<ConfirmationView>(includeInactive: true);
        if (confirmationMsg.isActiveAndEnabled)
        {
            return;
        }

        confirmationMsg.StartConfirmation(confirmation);
    }
}
