using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "new LevelData", menuName = "Game/Level")]
public class LevelData : ScriptableObject
{
    public Sprite icon;
    public string sceneName;
    public string levelName;
    public int levelNumber;
    public int id;
    public bool unlock = false;

    //public float highscore;
    //public float time;
    //public int start;
}
