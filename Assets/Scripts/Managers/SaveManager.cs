using System.IO;
using System.Threading.Tasks;
using NUnit.Framework.Constraints;
using UnityEngine;
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
    public PlayerDataSets gameSlot;
    public PlayerData currentSlot;
    private string settings;
    private string playerSaves;
    private string storyLine;
    private void Awake()
    {
        instance = this;
        DontDestroyOnLoad(gameObject);
        if(FindObjectsByType<SaveManager>(0).Length > 1)
        {
            Destroy(gameObject);
        }
        settings = Application.persistentDataPath + "/Settings.json";
        playerSaves = Application.persistentDataPath + "/PlayerSaves.json";
        storyLine = Application.persistentDataPath + "/StoryLine.json";
        LoadGameSettings();
        for (var i = 0; i < gameSlot.slot.Length; i++)
        {
            gameSlot.slot[i] = LoadPlayerData(i);
        }
    }
    void Start()
    {

    }

    
    void Update()
    {
        
    }
    public void SaveGameSettings(SettingsData newData)
    {
        string json = JsonUtility.ToJson(newData, true);
        File.WriteAllText(settings, json);
    }
    public void SavePlayerDataSets(PlayerDataSets playerDataSets)
    {
        string json = JsonUtility.ToJson(playerDataSets, true);
        File.WriteAllText(playerSaves, json);
    }

    public SettingsData LoadGameSettings()
    {
        if (File.Exists(settings))
        {
            string json = File.ReadAllText(settings);
            SettingsData data = JsonUtility.FromJson<SettingsData>(json);
            Debug.Log("게임 데이터 로드 성공!");
            return data;
        }
        else
        {
            Debug.LogWarning("저장된 파일 없음! 새로운 파일 생성!");
            SettingsData newData = new SettingsData();
            SaveGameSettings(newData);
            return newData;
        }
    }
    public PlayerData LoadPlayerData(int index)
    {
        if (File.Exists(playerSaves))
        {
            string json = File.ReadAllText(playerSaves);
            PlayerData data = JsonUtility.FromJson<PlayerDataSets>(json).slot[index];
            Debug.Log("게임 데이터 로드 성공!");
            return data;
        }
        else
        {
            Debug.LogWarning("저장된 파일 없음! 새로운 파일 생성!");
            PlayerDataSets newData = new PlayerDataSets();
            SavePlayerDataSets(newData);
            string json = File.ReadAllText(playerSaves);
            PlayerData data = JsonUtility.FromJson<PlayerDataSets>(json).slot[index];
            return data;
        }
    }
    public PlayerData DeletePlayerData(int index)
    {
        string json = File.ReadAllText(playerSaves);
        PlayerData data = JsonUtility.FromJson<PlayerDataSets>(json).slot[index];
        data = new PlayerData();
        gameSlot.slot[index] = data;
        SavePlayerDataSets(gameSlot);
        Debug.Log("게임 데이터 로드 성공!");
        return data;
    }
}