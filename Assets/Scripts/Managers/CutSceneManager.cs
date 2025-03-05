using System.Collections;
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
    [Header("�ش� �ƾ� ���ӿ�����Ʈ")]
    public GameObject cutScene;

    public void Start()
    {
        Debug.Log(MapManager.instance.currentMap.map);
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
        InGameEvents.isCutScene = false;
        InGameEvents.StartCut
        PlayerController.instance.DemandMoves(0);
        StartCoroutine(EndCutSceneFlow());
        
    }
    private IEnumerator EndCutSceneFlow()
    {
        AudioManager.instance.SetOriginVolume();
        yield return new WaitForSeconds(1f);
        Destroy(cutScene);
    }
}
