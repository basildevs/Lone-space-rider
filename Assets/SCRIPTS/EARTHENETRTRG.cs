using UnityEngine;
using UnityEngine.SceneManagement;

public class EarthSceneTrigger : MonoBehaviour
{
    public string landSceneName = "Land"; // name of your land scene

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Jet"))
        {
            SceneManager.LoadScene(landSceneName);
        }
    }
}