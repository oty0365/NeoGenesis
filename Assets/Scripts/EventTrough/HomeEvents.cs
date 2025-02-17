using UnityEngine;

public class HomeEvents : MonoBehaviour,IInGameEvent,ICutSceneEvent
{
    public static HomeEvents instance;
    public CutSceneData cutScenes;
    public AudioClip[] audioClips;
    public int gameEventIndex;
    public int cutSceneIndex;
    public bool isGameEvent;
    public bool isCutScene;
    void Start()
    {
        if (MapManager.instance.mapData.CutSceneData.ContainsKey(MapManager.instance.mapCode))
        {
            cutSceneIndex = MapManager.instance.mapData.CutSceneData[MapManager.instance.mapCode];
        }
        else
        {
            cutSceneIndex = 0;
            MapManager.instance.mapData.CutSceneData[MapManager.instance.mapCode] = cutSceneIndex;
        }
        if (MapManager.instance.mapData.MapEventData.ContainsKey(MapManager.instance.mapCode)) 
        {
            gameEventIndex = MapManager.instance.mapData.MapEventData[MapManager.instance.mapCode];
        }
        else
        {
            gameEventIndex = 0;
            MapManager.instance.mapData.MapEventData[MapManager.instance.mapCode] = gameEventIndex;
        }
    }

    void Update()
    {
        if (!isGameEvent)
        {
            CheckGameEvent();
        }
        if (!isCutScene)
        {
            cutSceneIndex = MapManager.instance.mapData.CutSceneData[MapManager.instance.mapCode];
            CheckCutSceneEvent();
        }
    }
    public void CheckGameEvent()
    {

    }
    public void CheckCutSceneEvent()
    {
        switch (cutSceneIndex)
        {
            case 0:
                TriggerCutSceneEvent(0);
                break;
            case 1:
                TriggerCutSceneEvent(1);
                break;
            case 2:
                TriggerCutSceneEvent(2);
                break;

        }
    }
    public void TriggerCutSceneEvent(int index)
    {
        isCutScene = true;
        Instantiate(cutScenes.cutScenePrefabs[index]);
        
    }
    public void TriggerGameEvent(int index)
    {
        isGameEvent = true;
    }
}
