using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class GameEndingController : MonoBehaviour
{
    public GameObject endingMessage;
    public GameObject endingScreen;

    public float firstDelay = 30f;
    public float secondDelay = 10f;

    void Start()
    {
        StartCoroutine(EndingSequence());
    }

    IEnumerator EndingSequence()
    {
        // wait 30 seconds
        yield return new WaitForSeconds(firstDelay);

        endingMessage.SetActive(true);

        // wait 10 seconds
        yield return new WaitForSeconds(secondDelay);

        endingScreen.SetActive(true);

        // freeze game
        Time.timeScale = 0f;

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void RestartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("space"); // your first scene
    }
}