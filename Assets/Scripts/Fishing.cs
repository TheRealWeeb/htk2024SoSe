using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using Vector3 = System.Numerics.Vector3;

public class Fishing : MonoBehaviour
{
    [SerializeField] private Slider fishingMeter;
    
    [SerializeField] private Button backButton;
    
    [SerializeField] private Image doPull;

    [SerializeField] private Image doNotPull;

    [SerializeField] private Button pullButton;

    [SerializeField] private ParticleSystem fish;

    [SerializeField] private GameObject player;

    private void Awake()
    {
        gameObject.SetActive(false);
        //DestroyOldResults();
    }

    public void StartFishing()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }
    
    private void FishIncoming()
    {
        
    }
}
