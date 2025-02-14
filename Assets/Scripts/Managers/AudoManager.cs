using System.Collections;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    public AudioClip currentBgmClip;
    public AudioSource bgmSource;


    private void Awake()
    {
        instance = this;
    }
    public void Play(bool loop)
    {
        bgmSource.Play();
        bgmSource.loop = loop;
        bgmSource.volume = 1.0f*0.05f*SettingsManager.instance.volume;
        
    }
    public void ChangeCurrentClip(AudioClip newClip)
    {
        currentBgmClip = newClip;
    }
    public void ClipFade(float time)
    {
        StartCoroutine(ClipFadeFlow(time));
    }
    private IEnumerator ClipFadeFlow(float time)
    {
        var leftTime = time;
        var curTime = 0.02f;
        for(var i = curTime; i <= time; i += Time.deltaTime)
        {
            bgmSource.volume*=leftTime/ i;
            leftTime = time - i;
            yield return null;
        }
    }

}
