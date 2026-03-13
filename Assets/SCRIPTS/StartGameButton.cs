using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGameButton : MonoBehaviour
{
    public string firstScene = "space";   // your first scene name

    public void StartGame()
    {
        SceneManager.LoadScene(firstScene);
    }
}