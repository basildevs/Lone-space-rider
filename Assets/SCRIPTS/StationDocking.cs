using UnityEngine;
using UnityEngine.SceneManagement;

public class StationDocking : MonoBehaviour
{
    public GameObject dockMessage;
    private bool jetNear = false;

    void Start()
    {
        if (dockMessage != null)
            dockMessage.SetActive(false);
    }

    void Update()
    {
        if (jetNear && Input.GetKeyDown(KeyCode.Return))
        {
            SceneManager.LoadScene("SpaceStationInterior");
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Jet"))
        {
            jetNear = true;

            if (dockMessage != null)
                dockMessage.SetActive(true);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Jet"))
        {
            jetNear = false;

            if (dockMessage != null)
                dockMessage.SetActive(false);
        }
    }
}