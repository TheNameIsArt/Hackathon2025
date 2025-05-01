using UnityEngine;
using UnityEngine.SceneManagement;

public class sceneloadertest : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            Debug.Log("R key pressed");
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
    public void Reset()
    {
        Debug.Log("Resetting scene");
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
