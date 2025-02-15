using UnityEngine;

public class CharacterSelection : MonoBehaviour
{
    public int currentType;
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
            SaveManager.instance.SavePlayerDataSets(SaveManager.instance.gameSlot);
            cutSceneManager.GetComponent<CutSceneManager>();
            cutSceneManager.EndCutScene();
        }

    }

}
