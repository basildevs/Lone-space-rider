using UnityEngine;
using System.Collections;

public class MoonMusicFade : MonoBehaviour
{
    public AudioSource moonMusic;
    public AudioSource travelMusic;

    public float fadeSpeed = 0.5f;

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Jet"))
        {
            StartCoroutine(SwitchMusic());
        }
    }

    IEnumerator SwitchMusic()
    {
        // fade out moon music
        while (moonMusic.volume > 0)
        {
            moonMusic.volume -= Time.deltaTime * fadeSpeed;
            yield return null;
        }

        moonMusic.Stop();

        // start travel music
        travelMusic.Play();

        while (travelMusic.volume < 0.4f)
        {
            travelMusic.volume += Time.deltaTime * fadeSpeed;
            yield return null;
        }
    }
}