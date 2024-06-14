using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtmoChangeTrigger : MonoBehaviour
{
    [Header("Parameter Change")] 
    
    [SerializeField] private string parameterName;

    [SerializeField] private float parameterValue;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("Player"))
        {
            AudioManager.instance.SetAtmoParameter(parameterName, parameterValue);
        }
    }
}
