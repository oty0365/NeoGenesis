using UnityEngine;

[CreateAssetMenu(fileName = "CutSceneData", menuName = "Scriptable Objects/CutSceneData")]
public class CutSceneData : ScriptableObject
{
    public GameObject[] cutScenePrefabs;
}
