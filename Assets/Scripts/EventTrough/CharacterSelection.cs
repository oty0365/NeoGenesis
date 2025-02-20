using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CharacterSelection : MonoBehaviour
{
    public int currentType;
    public string currentName;
    public TMP_InputField inputField;
    public GameObject confrimPannel;
    public CutSceneManager cutSceneManager;
    public AudioClip bgm;

    private void Start()
    {
        confrimPannel.SetActive(false);
        AudioManager.instance.SetBgm("CharacterSelection");
        AudioManager.instance.PlayBgm(true);

        
    }
    public void SelectCharacter(int type)
    {
        currentType = type;
        confrimPannel.SetActive(true);
    }
    public void ConfrimCharacter(int answer)
    {
        if (answer==0)
        {
            confrimPannel.SetActive(false);
        }
        else
        {
            SaveManager.instance.currentSlot.playerStatusData.playerType = currentType;
            SaveManager.instance.UpLoadPlayerDataInGameSlots();
            PlayerStatus.instance.UpdatePlayerCaracter(currentType);
            SaveManager.instance.SavePlayerDataSets(SaveManager.instance.gameSlot);
            cutSceneManager.GetComponent<CutSceneManager>();
            cutSceneManager.EndCutScene();
        }

    }
    public void SelectName()
    {
        if(inputField.text != "")
        {
            currentName = inputField.text;
            confrimPannel.SetActive(true);
        }
    }
    public void ConfrimName(int answer)
    {
        if (answer == 0)
        {
            confrimPannel.SetActive(false);
        }
        else
        {
            SaveManager.instance.currentSlot.playerStatusData.playerName = currentName;
            SaveManager.instance.UpLoadPlayerDataInGameSlots();
            SaveManager.instance.SavePlayerDataSets(SaveManager.instance.gameSlot);
            cutSceneManager.GetComponent<CutSceneManager>();
            AudioManager.instance.SetBgm("Home");
            cutSceneManager.EndCutScene();
        }
    }

}
