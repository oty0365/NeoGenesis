using UnityEngine;

[CreateAssetMenu(fileName = "CharacterSet", menuName = "Scriptable Objects/CharacterSet")]
public class CharacterSet : ScriptableObject
{
    public string characterCode;
    public CharacterInfo characterInfo;
}
