using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeStrawberryState : MonoBehaviour
{
    [SerializeField] private GameObject dayOneStrawberries;
    [SerializeField] private GameObject dayTwoStrawberries;
        
        private Collider collider;
    
        private void Awake()
        {
            collider = GetComponent<Collider>();
        }
    
        private void OnTriggerEnter(Collider other)
        {
            if (other.tag.Equals("Player"))
            {
                dayOneStrawberries.SetActive(false);
                dayTwoStrawberries.SetActive(true);
                collider.enabled = false;
            }
        }
}
