using UnityEngine;

[CreateAssetMenu(fileName = "MapSet", menuName = "Scriptable Objects/MapSet")]
public class MapSet : ScriptableObject
{
    public string mapCode;
    public MapInfo mapInfo;
}
