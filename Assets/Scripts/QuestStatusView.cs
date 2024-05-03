using System.Collections;
using System.Collections.Generic;
using System.Linq;
using DefaultNamespace;
using TMPro;
using UnityEngine;

public class QuestStatusView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI questStatusText;

    [SerializeField] private GameObject finishableIndicator;

    public void Set(IQuest quest)
    {
        questStatusText.text = quest.GetDisplayName();
        var isCompletable = GameState.GetCompletableQuests().Any(x => x.Quest.GetId() == quest.GetId());
        finishableIndicator.SetActive(isCompletable);
    }
}
