using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSlotUI : MonoBehaviour
{
    public int slot;
    public TextMeshProUGUI playerName;
    public TextMeshProUGUI Location;
    public static Action uiUpdate;
    void Start()
    {
        uiUpdate = UiUpdate;
        if (SaveManager.instance.gameSlot.slot[slot].playerStatusData.playerName == "")
        {
            playerName.text = "???";
        }
        else
        {
            playerName.text = SaveManager.instance.gameSlot.slot[slot].playerStatusData.playerName;
        }
        if (SaveManager.instance.gameSlot.slot[slot].mapData.curLocation == "")
        {
            Location.text = "???";
        }
        else
        {
            Location.text = SaveManager.instance.gameSlot.slot[slot].mapData.curLocation;
        }
    }

    void Update()
    {
        
    }
    public void UiUpdate()
    {
        Debug.Log("UpdatedUi");
    }
    public void OnClick(int index)
    {
        SaveManager.instance.LoadPlayerData(index);
        SceneManager.LoadScene("InGameScene");
    }
}
