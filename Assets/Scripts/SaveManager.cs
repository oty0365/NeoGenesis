using System.IO;
using System.Threading.Tasks;
using UnityEngine;
[System.Serializable]
public class PlayerData
{
    public PlayerStatusData playerStatusData;

}
public class SaveManager : MonoBehaviour
{
    public static SaveManager instance;
    public int[] slot;
    private string settings;
    private void Awake()
    {
        instance = this;
        DontDestroyOnLoad(gameObject);
        if(FindObjectsByType<SaveManager>(0).Length > 1)
        {
            Destroy(gameObject);
        }
    }
    void Start()
    {
        settings = Application.persistentDataPath + "/Settings.json";
        LoadGameSettings();
    }

    
    void Update()
    {
        
    }
    public void SaveGameSettings(SettingsData newData)
    {
        string json = JsonUtility.ToJson(newData, true);
        File.WriteAllText(settings, json);
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

}