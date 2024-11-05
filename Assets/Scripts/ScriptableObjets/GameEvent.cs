using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="newGameEvent", menuName = "Scriptables/GameEvent")]
public class GameEvent : ScriptableObject
{
    public List<GameEventListener> gameEventListeners;
    
    public void Register(GameEventListener listener)
    {
        gameEventListeners.Add(listener);
    }

    public void Unregister(GameEventListener listener)
    {
        gameEventListeners.Remove(listener);
    }

    public void Trigger()
    {
        foreach (GameEventListener listener in gameEventListeners)
        {
            listener.callback.Invoke();
        }
    }
}
