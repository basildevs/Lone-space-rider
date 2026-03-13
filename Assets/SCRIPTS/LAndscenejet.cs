using UnityEngine;

public class LandSceneJetStart : MonoBehaviour
{
    public GameObject player;
    public MonoBehaviour playerController;
    public MonoBehaviour jetController;

    public Transform enterPoint;
    public Transform exitPoint;

    public GameObject playerCamera;
    public GameObject jetCamera;

    private bool isInJet = true;

    void Start()
    {
        // place player in jet seat
        player.transform.position = enterPoint.position;
        player.transform.rotation = enterPoint.rotation;

        // disable walking
        if (playerController != null)
            playerController.enabled = false;

        // enable jet control
        if (jetController != null)
            jetController.enabled = true;

        // switch cameras
        if (playerCamera != null)
            playerCamera.SetActive(false);

        if (jetCamera != null)
            jetCamera.SetActive(true);
    }

    void Update()
    {
        if (isInJet && Input.GetKeyDown(KeyCode.E))
        {
            ExitJet();
        }
    }

    void ExitJet()
    {
        isInJet = false;

        // disable jet
        if (jetController != null)
            jetController.enabled = false;

        // move player outside
        if (exitPoint != null)
            player.transform.position = exitPoint.position;

        // enable walking
        if (playerController != null)
            playerController.enabled = true;

        // switch cameras back
        if (jetCamera != null)
            jetCamera.SetActive(false);

        if (playerCamera != null)
            playerCamera.SetActive(true);
    }
}