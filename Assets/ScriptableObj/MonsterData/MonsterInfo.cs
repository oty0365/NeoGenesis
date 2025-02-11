using UnityEngine;
using UnityEngine.Localization;

[CreateAssetMenu(fileName = "MonsterInfo", menuName = "Scriptable Objects/MonsterInfo")]
public class MonsterInfo : ScriptableObject
{
    public LocalizedString monsterName;
    public MonsterType monsterType;
    public int attack;
    public int hp;
    public int stamina;
    public int speed;
    public Sprite faceIcon;
    public Sprite icon;
    public Sprite oponetIcon;
    public int cardNumber;
    public LocalizedString desc;
}
