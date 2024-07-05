using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class OpenUiButton : MonoBehaviour
{
   [SerializeField] private GameObject screen;

   private void Awake()
   {
      GetComponent<Button>().onClick.AddListener(OpenUi);
   }

   private void OpenUi()
   {
      UiService.Open(screen);
   }
}
