using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;

public class CompleteQuestTrigger : MonoBehaviour
{
    [SerializeField] private string quest;
    
    private Collider collider;
    

    private void Awake()
    {
        collider = GetComponent<Collider>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("Player"))
        {
            GameState.CompleteQuest(quest);
            FindObjectOfType<QuestLogView>(true).ShowActiveQuests();
            collider.enabled = false;
        }
    }
}
