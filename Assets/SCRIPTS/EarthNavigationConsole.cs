using UnityEngine;
using System.Collections;

public class EarthNavigationConsole : MonoBehaviour
{
    public GameObject pressMessageUI;
    public GameObject activatedMessageUI;

    public AudioSource activationSound;

    public float messageDuration = 2f;

    private bool playerNear = false;
    private bool activated = false;

    void Start()
    {
        if (pressMessageUI != null)
            pressMessageUI.SetActive(false);

        if (activatedMessageUI != null)
            activatedMessageUI.SetActive(false);
    }

    void Update()
    {
        if (playerNear && !activated && Input.GetKeyDown(KeyCode.Q))
        {
            ActivateNavigation();
        }
    }

    void ActivateNavigation()
    {
        activated = true;

        if (pressMessageUI != null)
            pressMessageUI.SetActive(false);

        if (activatedMessageUI != null)
            activatedMessageUI.SetActive(true);

        if (activationSound != null)
            activationSound.Play();

        StartCoroutine(HideMessage());
    }

    IEnumerator HideMessage()
    {
        yield return new WaitForSeconds(messageDuration);

        if (activatedMessageUI != null)
            activatedMessageUI.SetActive(false);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerNear = true;

            if (!activated && pressMessageUI != null)
                pressMessageUI.SetActive(true);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerNear = false;

            if (pressMessageUI != null)
                pressMessageUI.SetActive(false);
        }
    }
}