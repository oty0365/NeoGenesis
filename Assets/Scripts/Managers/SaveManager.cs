using System.Collections.Generic;
using System.IO;
using UnityEditor.U2D.Aseprite;
using UnityEngine;

public interface IUpLoader
{
    public void UpLoadAndSaveData();
}
[System.Serializable]
public class PlayerData
{
    public PlayerStatusData playerStatusData;
    public CharacterInteractionData characterInteractionData;
    public MapData mapData;
}



[System.Serializable]
public class PlayerDataSets
{
    public PlayerData[] slot = new PlayerData[3];
}

public class SaveManager : MonoBehaviour
{
    public static SaveManager instance;
    public PlayerDataSets gameSlot = new PlayerDataSets();
    public PlayerData currentSlot;
    public int currentIndex;
    private string settings;
    private string playerSaves;

    private void Awake()
    {
        instance = this;
        DontDestroyOnLoad(gameObject);
        if (FindObjectsByType<SaveManager>(0).Length > 1)
        {
            Destroy(gameObject);
        }
        settings = Application.persistentDataPath + "/Settings.json";
        playerSaves = Application.persistentDataPath + "/PlayerSaves.json";
        LoadGameSettings();

        for (var i = 0; i < gameSlot.slot.Length; i++)
        {
            gameSlot.slot[i] = LoadPlayerData(i);
        }
    }

    public void SaveGameSettings(SettingsData newData)
    {
        string json = JsonUtility.ToJson(newData, true);
        File.WriteAllText(settings, json);
    }

    public void SavePlayerDataSets(PlayerDataSets playerDataSets)
    {
        foreach (var slot in playerDataSets.slot)
        {
            if (slot != null)
            {
                slot.characterInteractionData.serializedData = slot.characterInteractionData.ConvertToSerializableList(slot.characterInteractionData.InteractionData);
                slot.mapData.serializedCutSceneData = slot.mapData.ConvertToSerializableList(slot.mapData.CutSceneData);
                slot.playerStatusData.serializedItems = slot.playerStatusData.ConvertToSerializableItemList(slot.playerStatusData.Items);
                slot.playerStatusData.serializedMonsterCardDictionary = slot.playerStatusData.ConvertToSerializableList(slot.playerStatusData.MonsterCardDictionary);
            }
        }

        string json = JsonUtility.ToJson(playerDataSets, true);
        File.WriteAllText(playerSaves, json);
    }

    public SettingsData LoadGameSettings()
    {
        if (File.Exists(settings))
        {
            string json = File.ReadAllText(settings);
            return JsonUtility.FromJson<SettingsData>(json);
        }
        else
        {
            SettingsData newData = new SettingsData();
            SaveGameSettings(newData);
            return newData;
        }
    }

    public PlayerData LoadPlayerData(int index)
    {
        currentIndex = index;
        if (File.Exists(playerSaves))
        {
            string json = File.ReadAllText(playerSaves);
            PlayerDataSets dataSets = JsonUtility.FromJson<PlayerDataSets>(json);

            if (dataSets != null && dataSets.slot.Length > index)
            {
                currentSlot = dataSets.slot[index];
                currentSlot.characterInteractionData.InteractionData = currentSlot.characterInteractionData.ConvertToDictionary();
                currentSlot.mapData.CutSceneData = currentSlot.mapData.ConvertToDictionary(currentSlot.mapData.serializedCutSceneData);
                currentSlot.playerStatusData.Items = currentSlot.playerStatusData.ConvertToItemDictionary(currentSlot.playerStatusData.serializedItems);
                currentSlot.playerStatusData.MonsterCardDictionary = currentSlot.playerStatusData.ConvertToDictionary(currentSlot.playerStatusData.serializedMonsterCardDictionary);
                return currentSlot;
            }
        }

        PlayerDataSets newData = new PlayerDataSets();
        SavePlayerDataSets(newData);
        return newData.slot[index];
    }

    public void UpLoadPlayerDataInGameSlots()
    {
        gameSlot.slot[currentIndex] = currentSlot;
    }

    public PlayerData DeletePlayerData(int index)
    {
        if (File.Exists(playerSaves))
        {
            string json = File.ReadAllText(playerSaves);
            PlayerDataSets dataSets = JsonUtility.FromJson<PlayerDataSets>(json);

            dataSets.slot[index] = new PlayerData();
            SavePlayerDataSets(dataSets);
        }

        return new PlayerData();
    }
}
