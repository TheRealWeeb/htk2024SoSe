using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Object = UnityEngine.Object;

public static class UiService
{
    public static GameObject Open(GameObject screen)
    {
        var uiRoot = Object.FindObjectOfType<UiRoot>();
        if (uiRoot == null)
        {
            throw new Exception("No UiRoot found in scene.");
        }

        return Object.Instantiate(screen, uiRoot.transform);
    }
}
