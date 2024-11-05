using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateLevelComponent : MonoBehaviour
{
    public List<LevelData> levelData;
    public GameObject levelComponent;

    // Start is called before the first frame update
    void Start()
    {
        foreach (var data in levelData)
        {
            LevelComponent newLevel = Instantiate(levelComponent, transform).GetComponent<LevelComponent>();
            newLevel.Initialize(data);
            newLevel.actualLevelData = data;
        }
    }
}
