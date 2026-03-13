using UnityEngine;

public class JetDriveSound : MonoBehaviour
{
    public AudioSource driveSound;
    public MonoBehaviour jetController;

    void Update()
    {
        if (!jetController.enabled)
        {
            if (driveSound.isPlaying)
                driveSound.Stop();
            return;
        }

        bool jetMoving =
            Input.GetKey(KeyCode.W) ||
            Input.GetKey(KeyCode.S) ||
            Input.GetKey(KeyCode.A) ||
            Input.GetKey(KeyCode.D) ||
            Input.GetKey(KeyCode.Space) ||
            Input.GetKey(KeyCode.LeftShift);

        if (jetMoving)
        {
            if (!driveSound.isPlaying)
                driveSound.Play();
        }
        else
        {
            if (driveSound.isPlaying)
                driveSound.Stop();
        }
    }
}