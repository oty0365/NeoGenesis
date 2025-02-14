using TMPro;
using UnityEngine;

public class CutSceneManager : MonoBehaviour
{
    [Header("ÄÆ¾À·¹º§")]
    public int cutSceneLevel;
    [Header("ÄÆ¾À¼³Á¤")]
    public Dialouges dialouges;
    public int currentIndex;
    public TextMeshProUGUI cutSceneText;
    public TextMeshProUGUI nameText;
    [Header("ÇØ´ç ÄÆ¾À °ÔÀÓ¿ÀºêÁ§Æ®")]
    public GameObject cutScene;

    public void Start()
    {
        MapManager.instance.currentMap.map.SetActive(false);
    }
    public void PutText()
    {
        cutSceneText.text = dialouges.dialougeTexts[currentIndex]?.text.GetLocalizedString();
        nameText.text = dialouges.dialougeTexts[currentIndex]?.talkerName.GetLocalizedString();
    }
    public void ChangeText()
    {
        currentIndex++;

    } 
    public void EndCutScene()
    {
        MapManager.instance.mapData.cutSceneData[MapManager.instance.mapData.curLocation] = cutSceneLevel;
        MapManager.instance.currentMap.map.SetActive(true);
        Destroy(cutScene);
    }
}
