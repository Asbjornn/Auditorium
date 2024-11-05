using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTest : MonoBehaviour
{
    public int healthPoint;
    public GameEvent gameEvent;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeHit(int amount)
    {
        healthPoint -= amount;
    }

    public void TriggerGameEvent()
    {
        gameEvent.Trigger();
    }
}
