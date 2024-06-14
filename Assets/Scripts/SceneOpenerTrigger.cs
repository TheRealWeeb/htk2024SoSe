using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneOpenerTrigger : MonoBehaviour, IInteractable
{
    [SerializeField] private int buildIndex;
    
    public void Interact()
    {
        SceneManager.LoadScene(buildIndex);
    }
}
