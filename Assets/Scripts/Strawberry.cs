using System.Collections;
using System.Collections.Generic;
using System.Timers;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Strawberry : MonoBehaviour, IInteractable
{
    [SerializeField] private GameObject wateredPanel;
    [SerializeField] private TextMeshProUGUI wateredText;

    private float timer = 2f;

    private bool watered;

    private bool showWatered = false;
    
    


    private void Awake()
    {
        wateredPanel.SetActive(false);
        if (SceneManager.GetActiveScene().buildIndex == 1)
        {
            PlayerPrefs.SetInt("WateredCrop", 0);
        }
        
        watered = PlayerPrefs.GetInt("WateredCrop") == 1;
        
        if (watered)
        {
            gameObject.transform.GetChild(0).gameObject.SetActive(true);
        }
    }

    private void Update()
    {
        Timer();
    }
    public void Interact()
    {
        wateredPanel.SetActive(true);
        showWatered = true;
        gameObject.GetComponent<Collider>().enabled = false;
        PlayerPrefs.SetInt("WateredCrop", 1);
    }

    private void Timer()
    {
        if (showWatered)
        {
            timer -= Time.deltaTime;
        }

        if (timer <= 0)
        {
            timer = 2f;
            showWatered = false;
            wateredPanel.SetActive(false);
            wateredText.gameObject.SetActive(false);
        }
    }
}
