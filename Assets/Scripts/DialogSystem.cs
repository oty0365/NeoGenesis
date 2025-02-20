using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogManager : MonoBehaviour
{
    public static DialogManager instance;
    public bool isTalking;
    public GameObject dialogPannel;
    public Image rightCharacter;
    public Image leftCharacter;
    public TextMeshProUGUI diaText;
    public Dialouges currentDia;
    public int currentIndex;
    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
    }
    public void DoTalk(Dialouges startDia,int startIndex)
    {
        if (PlayerController.instance.canInteract)
        {
            isTalking = true;
            currentDia = startDia;
            currentIndex = startIndex;
            PlayerController.instance.DemandMoves(3);
            dialogPannel.SetActive(true);
            PutText(currentIndex);
        }
    }
    public void PutText(int index)
    {
        diaText.text = currentDia.dialougeTexts[index].text.GetLocalizedString();
        rightCharacter.sprite = currentDia.dialougeTexts[index]?.rightCharacter;
    }

    public void GotoNext()
    {
        if (isTalking)
        {
            if (currentIndex == currentDia.dialougeTexts.Length - 1)
            {

            }
            else
            {
                currentIndex++;
            }
        }

    }
}
