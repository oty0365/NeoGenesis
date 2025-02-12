using TMPro;
using UnityEngine;

public class CutSceneManager : MonoBehaviour
{
    [Header("�ƾ�����")]
    public int cutSceneLevel;
    [Header("�ƾ�����")]
    public Dialouges dialouges;
    public int currentIndex;
    public TextMeshProUGUI cutSceneText;
    public TextMeshProUGUI nameText;

    public void PutText()
    {
        cutSceneText.text = dialouges.dialougeTexts[currentIndex]?.text.ToString();
        nameText.text = dialouges.dialougeTexts[currentIndex]?.talkerName.ToString();
    }
    public void ChangeText()
    {
        currentIndex++;

    } 
    public void EndCutScene()
    {
        MapManager.instance.mapData.cutSceneData[MapManager.instance.mapCode] = cutSceneLevel;
    }
}
