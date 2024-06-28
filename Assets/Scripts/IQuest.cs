using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IQuest
{
    public string GetId();
    public bool IsHidden();
    string GetDisplayName();
    GameObject GetEndScreenPrefab();
}
