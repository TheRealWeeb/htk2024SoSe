using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class FadeScript : MonoBehaviour
{
    
    private void Awake()
    {
        GetComponent<MeshRenderer>().material.DOFade(0.0f, 3.0f);
    }
    public void Fade()
    {
        GetComponent<MeshRenderer>().material.DOFade(1.0f, 3.0f);
        GetComponent<MeshRenderer>().material.DOFade(0.0f, 3.0f);
    }
}
