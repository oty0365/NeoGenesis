using UnityEngine;

[CreateAssetMenu(fileName = "MonsterSet", menuName = "Scriptable Objects/MonsterSet")]
public class MonsterSet : ScriptableObject
{
    public string monsterCode;
    public MonsterInfo monsterInfo;
}
