using UnityEngine;
using System.Collections; // Ensure this is included for IEnumerator

public class SlashAnimation : MonoBehaviour
{
    // Hardcode the delay to 0.1 seconds directly here for testing
    private float delayBeforeDestroy = 0.1f;

    public void DestroySelf()
    {
        Debug.Log($"DestroySelf called on {gameObject.name}, waiting {delayBeforeDestroy} seconds before destruction.");
        StartCoroutine(WaitAndDestroy());
    }

    private IEnumerator WaitAndDestroy()
    {
        yield return new WaitForSeconds(delayBeforeDestroy); // Wait for 0.1 seconds
        Debug.Log($"Destroying {gameObject.name} after {delayBeforeDestroy} seconds.");
        Destroy(gameObject);
    }
}
