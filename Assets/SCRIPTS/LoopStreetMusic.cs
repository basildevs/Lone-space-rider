using UnityEngine;
using System.Collections;

public class LoopStreetMusic : MonoBehaviour
{
    public AudioSource travelMusic;
    public AudioSource loopStreetMusic;

    public float fadeSpeed = 0.5f;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Jet"))
        {
            StartCoroutine(EnterLoopStreet());
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Jet"))
        {
            StartCoroutine(LeaveLoopStreet());
        }
    }

    IEnumerator EnterLoopStreet()
    {
        // fade out travel music
        while (travelMusic.volume > 0)
        {
            travelMusic.volume -= Time.deltaTime * fadeSpeed;
            yield return null;
        }

        travelMusic.Stop();

        // start LoopStreet music
        loopStreetMusic.Play();

        while (loopStreetMusic.volume < 0.4f)
        {
            loopStreetMusic.volume += Time.deltaTime * fadeSpeed;
            yield return null;
        }
    }

    IEnumerator LeaveLoopStreet()
    {
        // fade out LoopStreet music
        while (loopStreetMusic.volume > 0)
        {
            loopStreetMusic.volume -= Time.deltaTime * fadeSpeed;
            yield return null;
        }

        loopStreetMusic.Stop();

        // start travel music again
        travelMusic.Play();

        while (travelMusic.volume < 0.4f)
        {
            travelMusic.volume += Time.deltaTime * fadeSpeed;
            yield return null;
        }
    }
}