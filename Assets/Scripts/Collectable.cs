using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;

public class Collectable : MonoBehaviour, IInteractable
{
   public ItemType type;
   public uint amount = 1;

   public void Interact()
   {
      Debug.Log("Collected" + name);

      GameState.AddItem(type, amount);
      Destroy(gameObject);
   }
}


