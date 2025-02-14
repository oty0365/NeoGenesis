using UnityEngine;

[CreateAssetMenu(fileName = "BgmSet", menuName = "Scriptable Objects/BgmSet")]
public class BgmSet : ScriptableObject
{
    public string bgmCode;
    public AudioClip bgm;
}
