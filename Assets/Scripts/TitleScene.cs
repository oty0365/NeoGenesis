
using System.Collections;
using UnityEngine;
using UnityEngine.Localization.Settings;
using UnityEngine.UI;

[System.Serializable]
public class SettingsData
{
    public float volume=100;
    public string lang="ko";
}
public class TitleScene : MonoBehaviour
{
    public static TitleScene instance;
    public Slider sound;
    public float volume;
    public string lang;
    public GameObject gameslotPannel;
    public GameObject menuPannel;
    void Awake()
    {
        instance = this;
    }
    private void Start()
    {

        gameslotPannel.SetActive(false);
        SettingsManager.instance.GetSettings();
        volume = SettingsManager.instance.volume;
        lang = SettingsManager.instance.lang;
        sound.value = volume;
        ChangeLanguage(lang);
        menuPannel.SetActive(false);
        GameSlotUI.uiUpdate();

    }
    public void OnLangChangeClicked(string type)
    {
        ChangeLanguage(type);
    }
    public void ChangeLanguage(string localeCode)
    {
        lang = localeCode;
        StartCoroutine(SetLocale(localeCode));
    }

    private IEnumerator SetLocale(string localeCode)
    {
        yield return LocalizationSettings.InitializationOperation;
        foreach (var locale in LocalizationSettings.AvailableLocales.Locales)
        {
            if (locale.Identifier.Code == localeCode)
            {
                LocalizationSettings.SelectedLocale = locale;
                Debug.Log("��� �����: " + localeCode);
                yield break;
            }
        }
    }
    public void StartGameClicked()
    {
        gameslotPannel.SetActive(true);
    }
    public void SettingsClicked()
    {
        menuPannel.SetActive(true);
    }
    public void QuitMenu()
    {
        menuPannel.SetActive(false);
    }
    public void OnSaveClicked()
    {
        SettingsManager.instance.SaveAllSettings(lang, sound.value);
    }
}
