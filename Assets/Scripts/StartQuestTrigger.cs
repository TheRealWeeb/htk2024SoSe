using System;
using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;

public class StartQuestTrigger : MonoBehaviour
{
    [SerializeField] private CollectionQuest quest;
    
    private Collider collider;

    private void Awake()
    {
        collider = GetComponent<Collider>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("Player"))
        {
            GameState.StartQuest(quest);
            FindObjectOfType<QuestLogView>(true).ShowActiveQuests();
            collider.enabled = false;

            
        }
    }
}
