using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class LevelStat
{
    public bool hasCrystals = true;
    public bool hasAllFruits = false;
    public bool levelPassed = false;
    public List<int> collectedFruits = new List<int>();

    public void save(){
       string str = JsonUtility.ToJson(Instance);
       PlayerPrefs.SetString("stats", str);
       PlayerPrefs.Save();
    }

    public void read()
    {
        string str = PlayerPrefs.GetString("stats", null);
        Instance = JsonUtility.FromJson<LevelStat>(str);
        if (Instance == null)
        {
            Instance = new LevelStat();
        }
    }

    public static LevelStat Instance = new LevelStat();
}
