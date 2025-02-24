using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Localization;

[CreateAssetMenu(fileName = "DialougeText", menuName = "Scriptable Objects/DialougeText")]
public class DialougeText : ScriptableObject
{
    public bool isMainCharacter;
    public LocalizedString talkerName;
    public LocalizedString text;
    public Sprite rightCharacter;
    public Sprite leftCharacter;
    public bool hasOptions;
    public Dialouges dialouges;
    public Action talkEvent;
}
