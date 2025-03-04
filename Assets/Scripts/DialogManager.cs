using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogManager : MonoBehaviour
{
    public static DialogManager instance;
    public bool isTalking;
    public GameObject dialogPannel;
    public GameObject selectionPannel;
    public Image rightCharacter;
    public Image leftCharacter;
    public string currentTalker;
    public TextMeshProUGUI characterName;
    public TextMeshProUGUI diaText;
    public Dialouges currentDia;
    public int characterindex;
    public int currentIndex;
    public bool rememberThisTalk;
    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
    }
    public void DoTalk(Dialouges startDia,int dialogIndex,int curIndex ,string currentTalker,bool willRemember)
    {
        if (PlayerController.instance.canInteract)
        {
            
            isTalking = true;
            currentDia = startDia;
            currentIndex = curIndex;
            characterindex = dialogIndex;
            PlayerController.instance.DemandMoves(3);
            dialogPannel.SetActive(true);
            selectionPannel.SetActive(false);
            rightCharacter.enabled = false;
            leftCharacter.enabled = false;
            rememberThisTalk = willRemember;
            PutText(currentIndex);

        }
    }
    public void PutText(int index)
    {
        if (currentDia.dialougeTexts[index].isMainCharacter)
        {
            characterName.text = PlayerStatus.instance.playerStatusData.playerName;
        }
        if (!currentDia.dialougeTexts[index].talkerName.IsEmpty)
        {
                characterName.text = currentDia.dialougeTexts[index].talkerName.GetLocalizedString();
        }
        diaText.text = currentDia.dialougeTexts[index].text.GetLocalizedString();
        if (currentDia.dialougeTexts[index].rightCharacter != null)
        {
            rightCharacter.enabled = true;
            rightCharacter.sprite = currentDia.dialougeTexts[index].rightCharacter;

        }
        if (currentDia.dialougeTexts[index].leftCharacter != null)
        {
            leftCharacter.enabled = true;
            leftCharacter.sprite = currentDia.dialougeTexts[index].leftCharacter;
        }
        if (currentDia.dialougeTexts[index].hasOptions)
        {
            selectionPannel.SetActive(true);
        }
        currentDia.dialougeTexts[index].ExcuteActions();
    }

    public void GotoNext()
    {
        if (isTalking)
        {
            if (currentIndex == currentDia.dialougeTexts.Length - 1)
            {
                EndTalk();
            }
            else
            {
                currentIndex++;
                PutText(currentIndex);
            }
        }

    }
    public void EndTalk()
    {
        isTalking = false;
        PlayerController.instance.DemandMoves(0);
        dialogPannel.SetActive(false);
        selectionPannel.SetActive(false);
        rightCharacter.enabled = false;
        leftCharacter.enabled = false;
        if (rememberThisTalk)
        {
            InteractionManager.instance.interactionData.InteractionData[currentTalker][characterindex] = currentIndex;
            InteractionManager.instance.UpLoadAndSaveData();
        }
    }
}
