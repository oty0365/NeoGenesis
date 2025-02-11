using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Mapdata
{
    public Vector2 pos;
    public string mapCode;
    public Dictionary<string,int>mapEvent = new Dictionary<string,int>();
}
public class MapManager : MonoBehaviour
{

    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
