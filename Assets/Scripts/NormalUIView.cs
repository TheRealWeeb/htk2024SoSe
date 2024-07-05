using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using UnityEngine;

public class NormalUIView : MonoBehaviour
{
    [SerializeField] private PauseMenu pauseScreen;
    
    private void Update()
    {
        
        if (Input.GetButtonDown("Menu"))
        {
            Pause();
        }
    }

    private void Pause()
    {
        UiService.Open(pauseScreen.gameObject);
    }
}
