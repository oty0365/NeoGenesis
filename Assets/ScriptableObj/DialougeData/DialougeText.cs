using UnityEngine;
using UnityEngine.Localization;

[CreateAssetMenu(fileName = "DialougeText", menuName = "Scriptable Objects/DialougeText")]
public class DialougeText : ScriptableObject
{
    public LocalizedString talkerName;
    public LocalizedString text;
    public Sprite rightCharacter;
    public Sprite leftCharacter;
    public bool hasOptions;
    public Dialouges dialouges;
}
