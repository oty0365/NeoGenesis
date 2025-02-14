using System.Collections.Generic;
using UnityEngine;

public interface IInGameEvent
{
    
    public void CheckGameEvent();
    public void TriggerGameEvent(int index);
}
public interface ICutSceneEvent
{
    public void CheckCutSceneEvent();
    public void TriggerCutSceneEvent(int index);
}
[System.Serializable]
public class MapData
{
    public Vector2 curPosition;
    public string curLocation;
    public string curMapCode;
    public Dictionary<string, int>cutSceneData = new Dictionary<string, int>();
    public Dictionary<string, int> mapEventData = new Dictionary<string, int>();
}
public class MapManager : MonoBehaviour
{
    public static MapManager instance;
    public string mapCode;
    public string mapName;
    public MapData mapData;
    public MapSets mapSets;
    public Dictionary<string,MapInfo> mapDict = new Dictionary<string,MapInfo>();
    public MapInfo currentMap;
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
        if (mapData.curLocation == "")
        {
            mapCode=mapData.curMapCode = "Home";
            mapName = mapDict[mapCode].mapName.GetLocalizedString();
        }
        Instantiate(mapDict[mapCode].map);

    }

    void Update()
    {
        
    }
}
