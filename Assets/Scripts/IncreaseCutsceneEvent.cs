using UnityEngine;

public class IncreaseCutsceneEvent : MonoBehaviour,EventsWhileTalk
{
    public void TalkEvent()
    {
        MapManager.instance.StartEventCutscene();
    }
}
