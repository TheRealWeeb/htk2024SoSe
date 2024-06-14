using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicScene : MonoBehaviour
{
   [Header("Scene")]
   
   [SerializeField] private Music music;

   private void Start()
   {
      AudioManager.instance.SetMusic(music);
   }
}
