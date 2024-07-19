using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using StarterAssets;
using UnityEngine;
using UnityEngine.InputSystem;

public class Collectable : MonoBehaviour, IInteractable
{
   public ItemType type;
   public uint amount = 1;

   private PlayerInput playerInput;
   private Animator animator;

   private void Awake()
   {
      playerInput = FindObjectOfType<PlayerInput>();
      animator = FindObjectOfType<ThirdPersonController>().GetComponent<Animator>();
   }

   public void Interact()
   {
      Debug.Log("Collected" + name);

      StartCoroutine("IsCollecting");
   }

   IEnumerator IsCollecting()
   {
      playerInput.enabled = false;
      animator.SetBool("isPickingUp", true);
      yield return new WaitForSeconds(1.333f);
      playerInput.enabled = true;
      animator.SetBool("isPickingUp", false);
      GameState.AddItem(type, amount);
      Destroy(gameObject);
   }
}


