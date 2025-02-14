using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    public AudioClip currentBgmClip;
    public AudioSource bgmSource;
    public BgmSets bgmSets;
    public Dictionary<string, BgmSet> bgmDict = new Dictionary<string, BgmSet>(); 
    private void Awake()
    {
        instance = this;
        foreach(var i in bgmSets.bgmSets)
        {
            bgmDict.Add(i.name, i);
        }
    }
    public void SetBgm(string code)
    {
        currentBgmClip = bgmDict[code].bgm;
        
    }
    public void PlayBgm(bool loop)
    {
        bgmSource.clip = currentBgmClip;
        bgmSource.loop = loop;
        //bgmSource.volume = 1.0f*0.01f*SettingsManager.instance.volume;
        bgmSource.Play();
        
    }
    public void ClipFade(float time)
    {
        StartCoroutine(ClipFadeFlow(time));
    }
    private IEnumerator ClipFadeFlow(float time)
    {
        float startVolume = bgmSource.volume; 
        float elapsedTime = 0f;

        while (elapsedTime < time)
        {
            elapsedTime += Time.deltaTime; 
            bgmSource.volume = Mathf.Lerp(startVolume, 0f, elapsedTime / time); 
            yield return null;
        }

        bgmSource.volume = 0f; 
    }

}
