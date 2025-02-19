using UnityEngine;
using UnityEngine.Localization;

[CreateAssetMenu(fileName = "MapInfo", menuName = "Scriptable Objects/MapInfo")]
public class MapInfo : ScriptableObject
{
    public LocalizedString mapName;
    public LocalizedString mapDesc;
    public AudioClip mapBgm;
    public float camSize;
    public GameObject map;
}
