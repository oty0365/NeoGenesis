using System.Collections.Generic;
using UnityEditor.U2D.Aseprite;
using UnityEngine;

[System.Serializable]
public class SerializableMonsterEntry
{
    public string key;
    public MonsterData value;

    public SerializableMonsterEntry(string key, MonsterData value)
    {
        this.key = key;
        this.value = value;
    }
}

[System.Serializable]
public class SerializableItemEntry
{
    public string key;
    public ItemData value;

    public SerializableItemEntry(string key, ItemData value)
    {
        this.key = key;
        this.value = value;
    }
}
[System.Serializable]
public class PlayerStatusData
{
    public string playerName;
    public int playerType;
    public MonsterData[] entry = new MonsterData[6];
    public List<MonsterData> monsters = new List<MonsterData>();
    public List<SerializableItemEntry> serializedItems = new List<SerializableItemEntry>();
    public List<SerializableDictionaryEntry> serializedMonsterCardDictionary = new List<SerializableDictionaryEntry>();
    private Dictionary<string,int> _monsterCardDictionary = new Dictionary<string,int>();
    private Dictionary<string, ItemData> _items = new Dictionary<string, ItemData>();
    public Dictionary<string, ItemData> Items
    {
        get
        {
            if (_items.Count == 0 && serializedItems.Count > 0)
            {
                _items = ConvertToItemDictionary(serializedItems);
            }
            return _items;
        }
        set
        {
            _items = value;
            serializedItems = ConvertToSerializableItemList(value);
        }
    }
    public Dictionary<string, int> MonsterCardDictionary 
    {
        get
        {
            if (_monsterCardDictionary.Count == 0 && serializedMonsterCardDictionary.Count > 0)
            {
                _monsterCardDictionary = ConvertToDictionary(serializedMonsterCardDictionary);
            }
            return _monsterCardDictionary;
        }
        set
        {
            _monsterCardDictionary = value;
            serializedMonsterCardDictionary = ConvertToSerializableList(value);
        }
    }
    public List<SerializableDictionaryEntry> ConvertToSerializableList(Dictionary<string, int> dict)
    {
        List<SerializableDictionaryEntry> list = new List<SerializableDictionaryEntry>();
        foreach (var pair in dict)
        {
            list.Add(new SerializableDictionaryEntry(pair.Key, pair.Value));
        }
        return list;
    }

    public Dictionary<string, int> ConvertToDictionary(List<SerializableDictionaryEntry> list)
    {
        Dictionary<string, int> dict = new Dictionary<string, int>();
        foreach (var entry in list)
        {
            dict[entry.key] = entry.value;
        }
        return dict;
    }

    public List<SerializableItemEntry> ConvertToSerializableItemList(Dictionary<string, ItemData> dict)
    {
        List<SerializableItemEntry> list = new List<SerializableItemEntry>();
        foreach (var pair in dict)
        {
            list.Add(new SerializableItemEntry(pair.Key, pair.Value));
        }
        return list;
    }

    public Dictionary<string, ItemData> ConvertToItemDictionary(List<SerializableItemEntry> list)
    {
        Dictionary<string, ItemData> dict = new Dictionary<string, ItemData>();
        foreach (var entry in list)
        {
            dict[entry.key] = entry.value;
        }
        return dict;
    }
}
public class PlayerStatus : MonoBehaviour,IUpLoader
{
    public static PlayerStatus instance;
    public Animator ani;
    public PlayerStatusData playerStatusData;
    public RuntimeAnimatorController[] playerAnimatorController;
    public float moveSpeed;
    private void Awake()
    {
        instance = this;

    }
    void Start()
    {
        playerStatusData = SaveManager.instance.currentSlot.playerStatusData;
        ani.runtimeAnimatorController = playerAnimatorController[playerStatusData.playerType];
    }
    public void UpdatePlayerCaracter(int playerType)
    {
        ani.runtimeAnimatorController = playerAnimatorController[playerType];
    }
    public void UpLoadAndSaveData()
    {
        SaveManager.instance.currentSlot.playerStatusData = playerStatusData;
        SaveManager.instance.gameSlot.slot[SaveManager.instance.currentIndex] = SaveManager.instance.currentSlot;
        SaveManager.instance.SavePlayerDataSets(SaveManager.instance.gameSlot);
    }
}
