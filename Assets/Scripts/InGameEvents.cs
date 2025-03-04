using UnityEngine;

public class InGameEvents : MonoBehaviour
{
    public static bool isGameEvent;
    public static bool isCutScene;
    public int gameEventIndex;

    public void IncreaseIndex()
    {
        gameEventIndex++;
    }
}
