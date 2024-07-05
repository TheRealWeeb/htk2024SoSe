using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;
using UnityEngine.InputSystem.LowLevel;

public class Openable : MonoBehaviour, IInteractable
{
   [SerializeField] private Animator _animator;

   [SerializeField] private ItemType _requiredItem;

   [SerializeField] private uint _requiredAmount;

   [SerializeField] private bool _shouldConsume;

   [SerializeField] private bool stayOpen;
   
   private bool _isOpen;

   public void Interact()
   {
      if (_isOpen)
      {
         return;
      }

      if (_shouldConsume)
      {
         if (GameState.TryRemoveItem(_requiredItem, _requiredAmount))
         {
            Open();
         }
      }
      else
      {
         if (GameState.HasEnoughItems(_requiredItem, _requiredAmount))
         {
            Open();
         }
      }
      
   }

   private void Open()
   {
      _isOpen = true;
      if (_animator != null)
      {
         _animator.SetBool("isOpen", true);   
      }
      
      
   }
}
