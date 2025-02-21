using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor.U2D.Aseprite;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;


public interface IInteractable
{
    public void OnInteract();
}
[System.Serializable]
public class SerializableNestedDictionaryEntry
{
    public string key;
    public List<SerializableDictionaryEntry> valueList = new List<SerializableDictionaryEntry>();

    public SerializableNestedDictionaryEntry(string key, int[] values)
    {
        this.key = key;
        for (int i = 0; i < values.Length; i++)
        {
            valueList.Add(new SerializableDictionaryEntry(i.ToString(), values[i])); 
        }
    }
}

[System.Serializable]
public class SerializableDictionaryEntry
{
    public string key;
    public int value;

    public SerializableDictionaryEntry(string key, int value)
    {
        this.key = key;
        this.value = value;
    }
}

[System.Serializable]
public class CharacterInteractionData
{
    public List<SerializableNestedDictionaryEntry> serializedData = new List<SerializableNestedDictionaryEntry>();
    private Dictionary<string, int[]> _interactionData = new Dictionary<string, int[]>();

    public Dictionary<string, int[]> InteractionData
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

    public List<SerializableNestedDictionaryEntry> ConvertToSerializableList(Dictionary<string, int[]> dict)
    {
        List<SerializableNestedDictionaryEntry> list = new List<SerializableNestedDictionaryEntry>();
        foreach (var pair in dict)
        {
            list.Add(new SerializableNestedDictionaryEntry(pair.Key, pair.Value));
        }
        return list;
    }

    public Dictionary<string, int[]> ConvertToDictionary()
    {
        Dictionary<string, int[]> dict = new Dictionary<string, int[]>();

        foreach (var entry in serializedData)
        {
            int[] values = entry.valueList
                .OrderBy(subEntry => int.Parse(subEntry.key)) 
                .Select(subEntry => subEntry.value) 
                .ToArray();

            dict[entry.key] = values;
        }
        return dict;
    }
}

public class InteractionManager : MonoBehaviour,IUpLoader
{
    public static InteractionManager instance;
    public CharacterInteractionData interactionData;
    public float intteractionRange;
    public LayerMask interactableMask;
    public string characterCode;
    public InteracterSets characterSets;
    public Dictionary<string,CharacterInfo> characterDict= new Dictionary<string,CharacterInfo>();
    public GameObject currentInteractingObj;
    public GameObject interactionButton;
    private void Awake()
    {
        instance = this;
        if(characterSets != null ) {
        foreach(var i in characterSets.interacterSets)
        {
            characterDict.Add(i.characterCode, i.characterInfo);
        }
        }
    }
    void Start()
    {
        interactionData = SaveManager.instance.currentSlot.characterInteractionData;
        interactionButton.SetActive(false);
        StartCoroutine(CheckSurround());
    }
    private IEnumerator CheckSurround()
    {
        Collider2D[] hitObjects = Physics2D.OverlapCircleAll(MapManager.instance.mapData.curPosition, intteractionRange, interactableMask);
        if (hitObjects.Length <= 0)
        {
            currentInteractingObj = null;
        }
        Collider2D closestObject = hitObjects.OrderBy(obj => Vector2.Distance(obj.transform.position, MapManager.instance.mapData.curPosition)).FirstOrDefault();
        if (closestObject != null)
        {
            if (!interactionButton.activeSelf)
            {
                interactionButton.SetActive(true);
            }
            currentInteractingObj = closestObject.gameObject;
            interactionButton.transform.position = new Vector2(currentInteractingObj.transform.position.x,currentInteractingObj.transform.position.y+0.5f);

        }
        else
        {
            if (interactionButton.activeSelf)
            {
                interactionButton.SetActive(false);
            }
        }
        yield return new WaitForSeconds(0.05f);
        StartCoroutine(CheckSurround());
    }


    public void UpLoadAndSaveData()
    {
        SaveManager.instance.currentSlot.characterInteractionData = interactionData;
        SaveManager.instance.gameSlot.slot[SaveManager.instance.currentIndex] = SaveManager.instance.currentSlot;
        SaveManager.instance.SavePlayerDataSets(SaveManager.instance.gameSlot);
    }
    public void StartInteract(InputAction.CallbackContext interaction)
    {
        if(currentInteractingObj != null)
        {
            currentInteractingObj.GetComponent<IInteractable>().OnInteract();
        }

    }
}
