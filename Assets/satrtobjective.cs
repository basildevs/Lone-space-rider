using UnityEngine;

public class StartObjectiveMessage : MonoBehaviour
{
    public GameObject messageUI;
    public float displayTime = 5f;

    void Start()
    {
        messageUI.SetActive(true);
        Invoke("HideMessage", displayTime);
    }

    void HideMessage()
    {
        messageUI.SetActive(false);
    }
}