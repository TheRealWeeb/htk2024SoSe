using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishingArea : MonoBehaviour, IInteractable
{
    [SerializeField] private GameObject fishingArea;
    public void Interact()
    {
        var fishingGame = FindObjectOfType<Fishing>(includeInactive: true);
        if (fishingGame.isActiveAndEnabled)
        {
            return;
        }

        fishingGame.OpenFishing(fishingArea);
        Debug.Log("Go.");
    }
}
