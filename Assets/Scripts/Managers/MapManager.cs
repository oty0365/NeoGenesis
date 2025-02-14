using System.Collections.Generic;
using UnityEngine;

public interface IMapCutScene
{
    
    public void CheckEvent();
}
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
    public Dictionary<string,MapInfo> mapDict = new Dictionary<string,MapInfo>();
    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        mapData = SaveManager.instance.currentSlot.mapData;
        foreach (var i in mapSets.mapSets)
        {
            mapDict.Add(i.mapCode, i.mapInfo);
        }
    }

    void Update()
    {
        
    }
}
