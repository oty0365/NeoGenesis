using UnityEngine;

public class HomeEvents : InGameEvents,ICutSceneEvent
{
    public CutSceneData cutScenes;
    public AudioClip[] audioClips;
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
        InitCutSceneEvent();
        StartCutSceneEvent();
    }


    public override void CheckCutSceneEvent()
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
            case 4:
                TriggerCutSceneEvent(3);
                break;
            case 5:
                break;

        }
    }
    public override void InitCutSceneEvent()
    {
        switch (cutSceneIndex)
        {
            case 3:
                AudioManager.instance.SetBgm("Home");
                AudioManager.instance.PlayBgm(true);
                break;
        }
    }
    public void TriggerCutSceneEvent(int index)
    {
        isCutScene = true;
        PlayerController.instance.DemandMoves(3);
        Instantiate(cutScenes.cutScenePrefabs[index]);
        
    }
}
