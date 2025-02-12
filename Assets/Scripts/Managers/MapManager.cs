using System.Collections.Generic;
using UnityEngine;
using static System.Net.WebRequestMethods;

[System.Serializable]
public class MapData
{
    public Vector2 curPosition;
    public string curLocation;
    public Dictionary<string, int>cutSceneData = new Dictionary<string, int>();
    public Dictionary<string, Dictionary<string, int>> mapData = new Dictionary<string, Dictionary <string,int>>();
}
public class MapManager : MonoBehaviour
{
    public static MapManager instance;
    public string mapCode;
    public MapData mapData;
    public MapSets mapSets;

    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        mapData = SaveManager.instance.currentSlot.mapData;
    }

    void Update()
    {
        
    }
}
