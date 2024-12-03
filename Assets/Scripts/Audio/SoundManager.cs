using UnityEngine;

public class SoundManager : MonoBehaviour
{
    // A static instance of the SoundManager class to ensure it follows the Singleton pattern.
    // This allows global access to the instance and ensures only one instance exists.
    public static SoundManager instance { get; private set; }

    // A private reference to the AudioSource component attached to this GameObject.
    private AudioSource source;

    private void Awake()
    {
        // Get the AudioSource component from this GameObject.
        source = GetComponent<AudioSource>();

        // Check if there is no existing instance of the SoundManager.
        if (instance == null)
        {
            // Assign this instance to the static instance variable.
            instance = this;

            // Prevent this GameObject from being destroyed when switching scenes.
            DontDestroyOnLoad(gameObject);
        }

        // If an instance already exists and it is not this one:
        else if (instance != null && instance != this)
        {
            // Destroy this duplicate GameObject to enforce the Singleton pattern.
            Destroy(gameObject);
        }
    }

    // A public method to play a sound clip using the AudioSource.
    public void PlaySound(AudioClip _sound)
    {
        // Play the provided AudioClip once, without interrupting currently playing sounds.
        source.PlayOneShot(_sound);
    }
}
