using System.Collections.Generic;
using UnityEngine;
using static System.Net.WebRequestMethods;

[System.Serializable]
public class MapData
{
    public Vector2 curPosition;
    public string curLocation;
    public Dictionary<string, Dictionary<string, int>> mapData = new Dictionary<string, Dictionary <string,int>>();
}
public class MapManager : MonoBehaviour
{
    public string mapCode;
    public MapData mapData;
    public MapSets mapSets;
    
    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
