using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseVariable<T> : ScriptableObject
{
    public T value;
}