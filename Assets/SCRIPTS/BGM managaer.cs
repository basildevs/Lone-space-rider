using UnityEngine;
using System.Collections;

public class BGMManager : MonoBehaviour
{
    public AudioSource audioSource;

    public AudioClip moonBGM;
    public AudioClip travelBGM;
    public AudioClip loopStreetBGM;
    public AudioClip stationBGM;

    public float fadeSpeed = 1.5f;

    public void PlayMusic(AudioClip newClip)
    {
        StopAllCoroutines();
        StartCoroutine(FadeMusic(newClip));
    }

    IEnumerator FadeMusic(AudioClip newClip)
    {
        // fade out
        while (audioSource.volume > 0)
        {
            audioSource.volume -= Time.deltaTime * fadeSpeed;
            yield return null;
        }

        audioSource.clip = newClip;
        audioSource.Play();

        // fade in
        while (audioSource.volume < 0.4f)
        {
            audioSource.volume += Time.deltaTime * fadeSpeed;
            yield return null;
        }
    }
}