using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using DefaultNamespace;
using UnityEngine;

public class SecretQuestTrigger : MonoBehaviour
{
    private List<IQuest> _quests;
    
    // [SerializeField] private CollectionQuest collectionQuest;
    [SerializeField] private CollectionQuest carolineFishing;
    [SerializeField] private CollectionQuest carolineSecretQuest;
    

    private Collider collider;

    private void Awake()
    {
        collider = GetComponent<Collider>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("Player"))
        {
            var questName = carolineFishing.ToString();
            var quest = _quests.First(q => q.GetId().ToLower() == questName.ToLower());
            if(GameState.IsQuestCompleted(quest))
            {
                GameState.StartQuest(carolineSecretQuest);
            }
            else
            {
                return;
            }
            FindObjectOfType<QuestLogView>(true).ShowActiveQuests();
            collider.enabled = false;
        }
            
    }
}
