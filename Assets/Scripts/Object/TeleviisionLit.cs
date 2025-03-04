using System.Collections;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class TeleviisionLit : MonoBehaviour
{
    public Light2D teleLight;

    void Start()
    {
        StartCoroutine(TelevisionBlink());
    }
    private IEnumerator TelevisionBlink()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(0.1f, 2.6f));
            teleLight.falloffIntensity = Random.Range(0.5f, 0.62f);
        }
    }

}
