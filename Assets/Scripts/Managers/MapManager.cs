using System.Collections.Generic;
using Newtonsoft.Json;
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
public interface IEventObjects
{
    public void TriggerEventObjects();
}
[System.Serializable]
public class MapData
{
    public Vector2 curPosition;
    public string curLocation;
    public string curMapCode;

    public List<SerializableDictionaryEntry> serializedCutSceneData = new List<SerializableDictionaryEntry>();
    public List<SerializableDictionaryEntry> serializedMapEventData = new List<SerializableDictionaryEntry>();

    public Dictionary<string, int> _cutSceneData = new Dictionary<string, int>();
    public Dictionary<string, int> _mapEventData = new Dictionary<string, int>();

    public Dictionary<string, int> CutSceneData
    {
        get
        {
            if (_cutSceneData.Count == 0 && serializedCutSceneData.Count > 0)
            {
                _cutSceneData = ConvertToDictionary(serializedCutSceneData);
            }
            return _cutSceneData;
        }
        set
        {
            _cutSceneData = value;
            serializedCutSceneData = ConvertToSerializableList(value);
        }
    }

    public Dictionary<string, int> MapEventData
    {
        get
        {
            if (_mapEventData.Count == 0 && serializedMapEventData.Count > 0)
            {
                _mapEventData = ConvertToDictionary(serializedMapEventData);
            }
            return _mapEventData;
        }
        set
        {
            _mapEventData = value;
            serializedMapEventData = ConvertToSerializableList(value);
        }
    }

    public List<SerializableDictionaryEntry> ConvertToSerializableList(Dictionary<string, int> dict)
    {
        List<SerializableDictionaryEntry> list = new List<SerializableDictionaryEntry>();
        foreach (var pair in dict)
        {
            list.Add(new SerializableDictionaryEntry(pair.Key, pair.Value));
        }
        return list;
    }

    public Dictionary<string, int> ConvertToDictionary(List<SerializableDictionaryEntry> list)
    {
        Dictionary<string, int> dict = new Dictionary<string, int>();
        foreach (var entry in list)
        {
            dict[entry.key] = entry.value;
        }
        return dict;
    }
}

public class MapManager : MonoBehaviour,IUpLoader
{
    public static MapManager instance;
    public string mapCode;
    public string mapName;
    public MapData mapData;
    public MapSets mapSets;
    public Dictionary<string,MapInfo> mapDict = new Dictionary<string,MapInfo>();
    public MapInfo currentMap;
    public GameObject mapObj;
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
            UpLoadAndSaveData();
            mapName = mapDict[mapCode].mapName.GetLocalizedString();
        }
        else
        {
            mapCode = mapData.curMapCode;
        }
        currentMap = mapDict[mapCode];
        Debug.Log(currentMap);
        SaveManager.instance.currentSlot.mapData.curLocation = mapDict[mapCode].mapName.GetLocalizedString();
        HeadCameraManager.instance.ChangeLens(currentMap.camSize);
        UpLoadAndSaveData();
        mapObj = Instantiate(currentMap.map);

    }
    public void UpLoadAndSaveData()
    {
        SaveManager.instance.currentSlot.mapData = mapData;
        SaveManager.instance.gameSlot.slot[SaveManager.instance.currentIndex] = SaveManager.instance.currentSlot;
        SaveManager.instance.SavePlayerDataSets(SaveManager.instance.gameSlot);
    }
    public void LoadMap(string mapCode)
    {
        mapData = SaveManager.instance.currentSlot.mapData;
        currentMap = mapDict[mapCode];
        SaveManager.instance.currentSlot.mapData.curLocation = mapDict[mapCode].mapName.GetLocalizedString();
        UpLoadAndSaveData();
        HeadCameraManager.instance.ChangeLens(currentMap.camSize);
        mapObj = Instantiate(currentMap.map);
    }
}
