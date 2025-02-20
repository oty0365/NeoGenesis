using System.Collections.Generic;
using UnityEditor.U2D.Aseprite;
using UnityEngine;


public interface IInteractable
{
    void OnInteract();
}
[System.Serializable]
public class SerializableNestedDictionaryEntry
{
    public string key;
    public List<SerializableDictionaryEntry> valueList = new List<SerializableDictionaryEntry>();

    public SerializableNestedDictionaryEntry(string key, Dictionary<string, int> valueDict)
    {
        this.key = key;
        foreach (var pair in valueDict)
        {
            valueList.Add(new SerializableDictionaryEntry(pair.Key, pair.Value));
        }
    }
}

[System.Serializable]
public class SerializableDictionaryEntry
{
    public string key;
    public int value;
    private string v;

    public SerializableDictionaryEntry(string key, int value)
    {
        this.key = key;
        this.value = value;
    }

    public SerializableDictionaryEntry(string key, string v)
    {
        this.key = key;
        this.v = v;
    }
}

[System.Serializable]
public class CharacterInteractionData
{
    public List<SerializableNestedDictionaryEntry> serializedData = new List<SerializableNestedDictionaryEntry>();
    private Dictionary<string, Dictionary<string, int>> _interactionData = new Dictionary<string, Dictionary<string, int>>();

    public Dictionary<string, Dictionary<string, int>> InteractionData
    {
        get
        {
            if (_interactionData.Count == 0 && serializedData.Count > 0)
            {
                _interactionData = ConvertToDictionary();
            }
            return _interactionData;
        }
        set
        {
            _interactionData = value;
            serializedData = ConvertToSerializableList(value);
        }
    }

    public List<SerializableNestedDictionaryEntry> ConvertToSerializableList(Dictionary<string, Dictionary<string, int>> dict)
    {
        List<SerializableNestedDictionaryEntry> list = new List<SerializableNestedDictionaryEntry>();
        foreach (var pair in dict)
        {
            list.Add(new SerializableNestedDictionaryEntry(pair.Key, pair.Value));
        }
        return list;
    }

    public Dictionary<string, Dictionary<string, int>> ConvertToDictionary()
    {
        Dictionary<string, Dictionary<string, int>> dict = new Dictionary<string, Dictionary<string, int>>();
        foreach (var entry in serializedData)
        {
            Dictionary<string, int> innerDict = new Dictionary<string, int>();
            foreach (var subEntry in entry.valueList)
            {
                innerDict[subEntry.key] = subEntry.value;
            }
            dict[entry.key] = innerDict;
        }
        return dict;
    }
}

public class InteractionManager : MonoBehaviour,IUpLoader
{
    public static InteractionManager instance;
    public CharacterInteractionData interactionData;
    public string characterCode;
    public InteracterSets characterSets;
    public Dictionary<string,CharacterInfo> characterDict= new Dictionary<string,CharacterInfo>();
    private void Awake()
    {
        instance = this;
        foreach(var i in characterSets.interacterSets)
        {
            characterDict.Add(i.characterCode, i.characterInfo);
        }
    }
    void Start()
    {
        interactionData = SaveManager.instance.currentSlot.characterInteractionData;
    }

    void Update()
    {
        
    }
    public void UpLoadAndSaveData()
    {
        SaveManager.instance.currentSlot.characterInteractionData = interactionData;
        SaveManager.instance.gameSlot.slot[SaveManager.instance.currentIndex] = SaveManager.instance.currentSlot;
        SaveManager.instance.SavePlayerDataSets(SaveManager.instance.gameSlot);
    }
}
