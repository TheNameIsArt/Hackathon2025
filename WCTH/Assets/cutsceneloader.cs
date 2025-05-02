using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class cutsceneloader : MonoBehaviour
{
    public VideoPlayer videoPlayer; // Reference to the VideoPlayer component
    public string sceneToLoad; // Name of the scene to load after the video finishes

    void Start()
    {
        if (videoPlayer != null)
        {
            // Subscribe to the loopPointReached event
            videoPlayer.loopPointReached += OnVideoFinished;
        }
        else
        {
            Debug.LogError("VideoPlayer is not assigned!");
        }
    }

    void OnVideoFinished(VideoPlayer vp)
    {
        // Load the specified scene when the video finishes
        SceneManager.LoadScene(sceneToLoad);
    }

    void OnDestroy()
    {
        // Unsubscribe from the event to avoid memory leaks
        if (videoPlayer != null)
        {
            videoPlayer.loopPointReached -= OnVideoFinished;
        }
    }
}
