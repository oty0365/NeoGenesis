using UnityEngine;

public class SettingsManager : MonoBehaviour
{
    public static SettingsManager instance;
    public float volume;
    public string lang;
    public SettingsData settings;
    private void Awake()
    {
        instance = this;
        DontDestroyOnLoad(gameObject);
        if (FindObjectsByType<SaveManager>(0).Length > 1)
        {
            Destroy(gameObject);
        }
    }
    public void GetSettings()
    {
        settings = SaveManager.instance.LoadGameSettings();
        lang = settings.lang;
        volume = settings.volume;
    }
    public void SaveAllSettings(string lag,float vol)
    {
        settings.lang = lag;
        settings.volume = vol;
        lang = settings.lang;
        volume = settings.volume;
        SaveManager.instance.SaveGameSettings(settings);
    }
}
