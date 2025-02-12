using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerStatusData
{
    public string playerName;
    public int playerType;
    public Dictionary<string, MonsterData> entry;
    public Dictionary<string, MonsterData> monsters;
    public Dictionary<string, ItemData> items;

}
public class PlayerStatus : MonoBehaviour
{
   
    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
