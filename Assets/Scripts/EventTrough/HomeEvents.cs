using UnityEngine;

public class HomeEvents : InGameEvents,IInGameEvent,ICutSceneEvent
{
    public CutSceneData cutScenes;
    public AudioClip[] audioClips;
    public int gameEventIndex;
    public int cutSceneIndex;

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
        switch (cutSceneIndex)
        {
            case 3:
                AudioManager.instance.SetBgm("Home");
                AudioManager.instance.PlayBgm(true);
                break;
        }
    }

    void Update()
    {
        cutSceneIndex = MapManager.instance.mapData.CutSceneData[MapManager.instance.mapCode];
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
            case 2:
                TriggerCutSceneEvent(2);
                break;
            case 3:
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
