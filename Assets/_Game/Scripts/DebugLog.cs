using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "DebugLog", menuName = "New DebugLogger", order = 150)]
public class DebugLog : ScriptableObject
{
    public void BebugLog(string _debug)
    {
        Debug.Log(_debug);
    }

    public void WarningLog(string _debug)
    {
        Debug.LogWarning(_debug);
    }

    public void ErrorLog(string _debug)
    {
        Debug.LogError(_debug);
    }
}
