using UnityEngine;

public class JetEnterSystem : MonoBehaviour
{
    [Header("References")]
    public GameObject player;
    public MonoBehaviour playerController;
    public MonoBehaviour jetController;

    public Transform enterPoint;
    public Transform exitPoint;

    public GameObject enterUI;

    public GameObject playerCamera;
    public GameObject jetCamera;

    [Header("Navigation")]
    public GameObject trailGuide;

    public bool autoEnterJetOnStart = false;

    private bool playerNear = false;
    private bool isInJet = false;

    void Start()
    {
        if (autoEnterJetOnStart)
        {
            EnterJet();
            return;
        }

        if (jetController != null)
            jetController.enabled = false;

        if (enterUI != null)
            enterUI.SetActive(false);

        if (jetCamera != null)
            jetCamera.SetActive(false);

        if (playerCamera != null)
            playerCamera.SetActive(true);

        if (trailGuide != null)
            trailGuide.SetActive(false);
    }

    void Update()
    {
        if (playerNear && !isInJet && Input.GetKeyDown(KeyCode.F))
        {
            EnterJet();
        }

        if (isInJet && Input.GetKeyDown(KeyCode.E))
        {
            ExitJet();
        }
    }

    void EnterJet()
    {
        isInJet = true;

        if (playerController != null)
            playerController.enabled = false;

        if (enterPoint != null)
        {
            player.transform.position = enterPoint.position;
            player.transform.rotation = enterPoint.rotation;
        }

        if (jetController != null)
            jetController.enabled = true;

        if (playerCamera != null)
            playerCamera.SetActive(false);

        if (jetCamera != null)
            jetCamera.SetActive(true);

        if (enterUI != null)
            enterUI.SetActive(false);

        if (trailGuide != null)
            trailGuide.SetActive(true);
    }

    void ExitJet()
    {
        isInJet = false;

        if (jetController != null)
            jetController.enabled = false;

        if (exitPoint != null)
            player.transform.position = exitPoint.position;

        if (playerController != null)
            playerController.enabled = true;

        if (jetCamera != null)
            jetCamera.SetActive(false);

        if (playerCamera != null)
            playerCamera.SetActive(true);

        if (trailGuide != null)
            trailGuide.SetActive(false);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player)
        {
            playerNear = true;

            if (!isInJet && enterUI != null)
                enterUI.SetActive(true);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject == player)
        {
            playerNear = false;

            if (enterUI != null)
                enterUI.SetActive(false);
        }
    }
}