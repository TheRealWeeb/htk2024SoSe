using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using Unity.VisualScripting;
using UnityEngine;

public class QuestLogView : MonoBehaviour
{
    [SerializeField] private RectTransform questsHolder;

    [SerializeField] private QuestStatusView questViewPrefab;

    private void Awake()
    {
        ShowActiveQuests();
    }
    
    public void ShowActiveQuests()
    {
        foreach (Transform child in questsHolder)
        {
            Destroy(child.gameObject);
        }

        var activeQuests = GameState.GetActiveQuests();
        if (activeQuests.Count == 0)
        {
            gameObject.SetActive(false);
            return;
        }
        
        foreach (var quest in activeQuests)
        {
            if (quest.Status == GameState.QuestStatus.Completed)
            {
                continue;
            }

            if (quest.Quest.IsHidden())
            {
                continue;
            }
            
            var questView = Instantiate(questViewPrefab, questsHolder);
            questView.Set(quest.Quest);
        }
    }
}
