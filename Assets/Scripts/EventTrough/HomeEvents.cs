using UnityEngine;

public class HomeEvents : MonoBehaviour,IInGameEvent,ICutSceneEvent
{

    public CutSceneData cutScenes;
    public int gameEventIndex;
    public int cutSceneIndex;
    public bool isGameEvent;
    public bool isCutScene;
    void Start()
    {
        if (MapManager.instance.mapData.cutSceneData.ContainsKey(MapManager.instance.mapCode))
        {
            cutSceneIndex = MapManager.instance.mapData.cutSceneData[MapManager.instance.mapCode];
        }
        else
        {
            cutSceneIndex = 0;
            MapManager.instance.mapData.cutSceneData[MapManager.instance.mapCode] = cutSceneIndex;
        }
        if (MapManager.instance.mapData.mapEventData.ContainsKey(MapManager.instance.mapCode)) 
        {
            gameEventIndex = MapManager.instance.mapData.mapEventData[MapManager.instance.mapCode];
        }
        else
        {
            gameEventIndex = 0;
            MapManager.instance.mapData.mapEventData[MapManager.instance.mapCode] = gameEventIndex;
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
