using UnityEngine;

public class InGameEvents : MonoBehaviour
{
    public static bool isGameEvent;
    public static bool isCutScene;
    public int gameEventIndex;
        public int cutSceneIndex;

    public void IncreaseIndex()
    {
        gameEventIndex++;
    }
    public virtual void CheckCutSceneEvent(){}
    public virtual void InitCutSceneEvent(){}

    public void StartCutSceneEvent()
    {
        cutSceneIndex = MapManager.instance.mapData.CutSceneData[MapManager.instance.mapCode];
        if (!isCutScene)
        {
            CheckCutSceneEvent();
        }
    }
}
