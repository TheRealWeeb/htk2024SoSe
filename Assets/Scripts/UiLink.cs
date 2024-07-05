using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiLink : MonoBehaviour
{
    [SerializeField] private GameObject screen;

    private GameObject screenInstance;

    public void Open()
    {
        screenInstance = UiService.Open(screen);
    }

    public void Close()
    {
        if (screenInstance != null)
        {
            Destroy(screenInstance.gameObject);
        }
    }
}
