using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public enum MonsterEffect
{
    None,
    Burn,
    Poision,
    Sleep,
    Frozen,
    Stun,
    Paralized,
    Bleed,
    Dead
}
[System.Serializable]
public enum MonsterType
{
    None,
    Fire,
    Water,
    Leaf,
    Ice,
    Dark,
    Light,
    Poisoin,
    Electric,
    Iron,
    Fist,
    Stone,
}
[System.Serializable]
public class MonsterData
{
    public string monsterCode;
    public string nickName;
    public int attackPlus;
    public int hpPlus;
    public int speedPlus;
    public int stamina;
    public int level;
    public int curExp;
    public int maxExp;
    public int maxHp;
    public int curHp;
    public int originAttack;
    public int originHp;
    public int originSpeed;
    public int originStamina;
    public MonsterEffect effect;
}
public class MonsterManager : MonoBehaviour 
{
    public static MonsterManager instance;
    public MonsterSets monsterSet;
    public Dictionary<string, MonsterInfo> monsterDict = new Dictionary<string, MonsterInfo>();
    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        foreach( var i in monsterSet.monsterSets)
        {
            monsterDict.Add(i.monsterCode, i.monsterInfo);
        }
    }
    void Update()
    {
        
    }
}
