using UnityEngine;

public class LoopStreetNavigationConsole : MonoBehaviour
{
    public GameObject pressUI;     // "Press Q to activate navigation"
    public GameObject deniedUI;    // "ACCESS DENIED - Keycard Required"
    public GameObject trail;

    public AudioSource errorSound;     // access denied sound
    public AudioSource activateSound;  // navigation activated sound

    private bool playerNear = false;

    void Start()
    {
        if (pressUI != null)
            pressUI.SetActive(false);

        if (deniedUI != null)
            deniedUI.SetActive(false);

        if (trail != null)
            trail.SetActive(false);
    }

    void Update()
    {
        if (playerNear && Input.GetKeyDown(KeyCode.Q))
        {
            if (!KeycardPickup.hasKeycard)
            {
                ShowDeniedMessage();

                if (errorSound != null)
                    errorSound.Play();
            }
            else
            {
                ActivateTrail();
            }
        }
    }

    void ActivateTrail()
    {
        if (trail != null)
            trail.SetActive(true);

        if (pressUI != null)
            pressUI.SetActive(false);

        if (activateSound != null)
            activateSound.Play();
    }

    void ShowDeniedMessage()
    {
        if (deniedUI != null)
        {
            deniedUI.SetActive(true);
            Invoke("HideDeniedMessage", 2f);
        }
    }

    void HideDeniedMessage()
    {
        if (deniedUI != null)
            deniedUI.SetActive(false);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerNear = true;

            if (pressUI != null)
                pressUI.SetActive(true);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerNear = false;

            if (pressUI != null)
                pressUI.SetActive(false);
        }
    }
}