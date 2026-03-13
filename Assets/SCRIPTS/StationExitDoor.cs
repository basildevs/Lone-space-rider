using UnityEngine;
using UnityEngine.SceneManagement;

public class StationExitDoor : MonoBehaviour
{
    public GameObject exitMessage;
    private bool playerNear = false;

    void Start()
    {
        if (exitMessage != null)
            exitMessage.SetActive(false);
    }

    void Update()
    {
        if (playerNear && Input.GetKeyDown(KeyCode.X))
        {
            // Load the new space scene where the jet is docked
            SceneManager.LoadScene("space 2");
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerNear = true;

            if (exitMessage != null)
                exitMessage.SetActive(true);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerNear = false;

            if (exitMessage != null)
                exitMessage.SetActive(false);
        }
    }
}