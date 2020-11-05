using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioFadeout : MonoBehaviour
{
    public static IEnumerator FadeOut(GameObject bgm, AudioSource audioSource, float FadeTime)
    {
        bgm.GetComponent<PlayBGM>().enabled = false;

        while (audioSource.volume > 0)
        {
            audioSource.volume -= Time.deltaTime * FadeTime;

            yield return null;
        }
    }

    public static IEnumerator FadeIn(GameObject bgm, AudioSource audioSource, float FadeTime)
    {
        while (audioSource.volume < 0.25f)
        {
            audioSource.volume += Time.deltaTime * FadeTime;

            yield return null;
        }

        if (audioSource.volume > 0.25f)
        {
            audioSource.volume = 0.25f;
        }

        bgm.GetComponent<PlayBGM>().enabled = true;
    }
}
