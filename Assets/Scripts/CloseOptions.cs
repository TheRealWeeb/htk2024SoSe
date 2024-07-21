using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CloseOptions : MonoBehaviour
{
    private void Awake()
    {
        GetComponent<Button>().onClick.AddListener(Close);
    }

    private void Close()
    {
        gameObject.transform.parent.gameObject.SetActive(false);
    }
}
