using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;

public class FMODEvents : MonoBehaviour
{
    [field: Header("Atmo")]
    [field: SerializeField] public EventReference atmo { get; private set; }
    
    
    [field: Header("Player SFX")]
    [field: SerializeField] public EventReference playerFootstepsGrass { get; private set; }
    [field: SerializeField] public EventReference plantingStrawberry { get; private set; }
    [field: SerializeField] public EventReference wateringCan { get; private set; }
    [field: SerializeField] public EventReference fishBiting { get; private set; }
    [field: SerializeField] public EventReference fishCaught { get; private set; }
    [field: SerializeField] public EventReference shakingTree { get; private set; }
    [field: SerializeField] public EventReference pickUp { get; private set; }
    
    [field: Header("Music")]
    [field: SerializeField] public EventReference music { get; private set; }
    
    
    [field: Header("Button SFX")]
    [field: SerializeField] public EventReference buttonNavigation { get; private set; }
    [field: SerializeField] public EventReference buttonClick { get; private set; }
    [field: SerializeField] public EventReference buttonBack { get; private set; }
    
    
    
    public static FMODEvents instance { get; private set; }

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("Found more than one FMOD Events instance in the scene.");
        }

        instance = this;
    }
}
