using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicChangeTrigger : MonoBehaviour
{
    [Header("Scene")]
   
    [SerializeField] private Music music;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("Player"))
        {
            AudioManager.instance.SetMusic(music);
        }
    }
}
