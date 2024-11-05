using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "new ScriptableVariable", menuName = "Test/ScriptableObject", order = 0)]
public class ScriptableVariable : ScriptableObject
{
    public int value;
    public Rank rank;
}

public enum Rank
{
    test,
    hype,
    none
}
