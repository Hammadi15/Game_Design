using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public AudioClip sceneMusic; // Assign this in the Inspector for each scene.

    private void Start()
    {
        if (SoundManager.instance != null && sceneMusic != null)
        {
            SoundManager.instance.ChangeBackgroundMusic(sceneMusic);
        }
    }
}
