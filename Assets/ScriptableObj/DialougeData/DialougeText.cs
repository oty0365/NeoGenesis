using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Localization;

public interface EventsWhileTalk
{
    public void TalkEvent();
} 
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
    public GameObject[] talkEventObjs;

    public void ExcuteActions()
    {
        if (talkEventObjs.Length > 0)
        {
            foreach (var i in talkEventObjs)
            {
                i.GetComponent<EventsWhileTalk>().TalkEvent();
            }
        }
    }
}
