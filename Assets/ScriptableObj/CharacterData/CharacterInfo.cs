using UnityEngine;
using UnityEngine.Localization;

[CreateAssetMenu(fileName = "CharacterInfo", menuName = "Scriptable Objects/CharacterInfo")]
public class CharacterInfo : ScriptableObject
{
    public LocalizedString characterName;
    public LocalizedString characterDescription;
    public Sprite characterSprite;
}
