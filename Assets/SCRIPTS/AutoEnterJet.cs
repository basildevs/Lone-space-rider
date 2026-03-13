using UnityEngine;

public class AutoEnterJet : MonoBehaviour
{
    public GameObject player;
    public MonoBehaviour playerController;
    public MonoBehaviour jetController;

    public Transform enterPoint;

    public GameObject playerCamera;
    public GameObject jetCamera;

    void Start()
    {
        // Move player into cockpit
        player.transform.position = enterPoint.position;
        player.transform.rotation = enterPoint.rotation;

        // Disable player walking
        if (playerController != null)
            playerController.enabled = false;

        // Enable jet control
        if (jetController != null)
            jetController.enabled = true;

        // Switch cameras
        if (playerCamera != null)
            playerCamera.SetActive(false);

        if (jetCamera != null)
            jetCamera.SetActive(true);
    }
}