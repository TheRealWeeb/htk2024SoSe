using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonAuido : MonoBehaviour
{
    public void NavigationSound()
    {
        AudioManager.instance.PlayOneShot(FMODEvents.instance.buttonNavigation, this.transform.position);
    }
    
    public void ClickSound()
    {
        AudioManager.instance.PlayOneShot(FMODEvents.instance.buttonClick, this.transform.position);
    }
    
    public void BackSound()
    {
        AudioManager.instance.PlayOneShot(FMODEvents.instance.buttonBack, this.transform.position);
    }
}
