using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneOpenerButton : MonoBehaviour
{
 [SerializeField]
 private int buildIndex;
 
 private void Awake()
 {
  GetComponent<Button>().onClick.AddListener(LoadScene);
  Cursor.visible = true;
  Cursor.lockState = CursorLockMode.None;
 }

 private void LoadScene()
 {
  Cursor.visible = false;
  Cursor.lockState = CursorLockMode.Locked;
  SceneManager.LoadScene(buildIndex);
 }
 
}
