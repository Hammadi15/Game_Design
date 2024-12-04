using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.SceneManagement;

public class LightManager : MonoBehaviour
{
    private Light2D playerLight;

    private void Awake()
    {
        // Get the Light 2D component
        playerLight = GetComponent<Light2D>();

        // Check if the Light 2D component exists
        if (playerLight == null)
        {
            Debug.LogError("Light2D component is missing on the Player GameObject!");
            return;
        }

        // Subscribe to scene change event
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDestroy()
    {
        // Unsubscribe from the event
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // Customize light properties based on the scene
        switch (scene.name) // Or you can use scene.buildIndex
        {
            case "jack_TutorialScene": // Replace with your scene name
                playerLight.enabled = false;
                break;

            case "jack_Map_Building": // Replace with your scene name
                playerLight.enabled = true;
                break;

            case "jack_Boss_Room": // Replace with your scene name
                playerLight.enabled = true;
                break;

            default:
                // Default settings for other scenes
                playerLight.enabled = false;
                break;
        }
    }
}
