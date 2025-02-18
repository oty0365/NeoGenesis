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
        Debug.Log(MapManager.instance.currentMap.map);
        //MapManager.instance.currentMap.map.SetActive(false);
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
    public void PlayBgm(string code)
    {
        AudioManager.instance.SetBgm(code);
        AudioManager.instance.PlayBgm(false);
    }
    public void FadeBgm(float time)
    {
        AudioManager.instance.ClipFade(time);
    }

    public void EndCutScene()
    {
        MapManager.instance.mapData.CutSceneData[MapManager.instance.mapCode] = cutSceneLevel;
        MapManager.instance.UpLoadAndSaveData();
        MapManager.instance.currentMap.map.SetActive(true);
        Destroy(cutScene);
    }
}
