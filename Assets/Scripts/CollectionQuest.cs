using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class CollectionQuest : ScriptableObject, IQuest
{
    public string displayName;
    public List<ItemRequirement> requirements;
    public bool isHidden;
    public GameObject endScreenPrefab;

    public string GetId()
    {
        return name;
    }

    public bool IsHidden()
    {
        return isHidden;
    }

    public string GetDisplayName()
    {
        return displayName;
    }

    public GameObject GetEndScreenPrefab()
    {
        return endScreenPrefab;
    }

    [Serializable]
    public class ItemRequirement
    {
        public ItemType type;
        public uint amount = 1;
    }
}
