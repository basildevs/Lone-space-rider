using UnityEngine;

public class KeycardPickup : MonoBehaviour
{
    public static bool hasKeycard = false;

    public AudioSource pickupSound;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            hasKeycard = true;

            if (pickupSound != null)
                pickupSound.Play();

            Destroy(gameObject, 0.2f); // small delay so sound plays
        }
    }
}