using UnityEngine;

public class MoonNavigationConsole : MonoBehaviour
{
    public GameObject messageUI;   // "Press Q to activate Moon tracker"
    public GameObject moonTrail;   // Trail to LoopStreet
    public AudioSource navigationSound; // activation sound

    private bool playerNear = false;
    private bool activated = false;

    void Start()
    {
        if (messageUI != null)
            messageUI.SetActive(false);

        if (moonTrail != null)
            moonTrail.SetActive(false);
    }

    void Update()
    {
        if (playerNear && !activated && Input.GetKeyDown(KeyCode.Q))
        {
            activated = true;

            if (messageUI != null)
                messageUI.SetActive(false);

            if (moonTrail != null)
                moonTrail.SetActive(true);

            // PLAY NAVIGATION SOUND
            if (navigationSound != null)
                navigationSound.Play();
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerNear = true;

            if (!activated && messageUI != null)
                messageUI.SetActive(true);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerNear = false;

            if (messageUI != null)
                messageUI.SetActive(false);
        }
    }
}