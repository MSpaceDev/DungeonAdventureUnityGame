using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public static LevelManager instance;

    public string sceneToLoad;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            Load(sceneToLoad);
        }
        else if (instance != this)
            Destroy(gameObject);
    }

    public void LoadUnload(string sceneToLoad, string sceneToUnload)
    {
        StartCoroutine(LoadUnloadScene(sceneToLoad, sceneToUnload));
    }

    public void Reset(string sceneToReset)
    {
        StartCoroutine(LoadUnloadScene(sceneToReset, sceneToReset));
    }

    public void Load(string scene)
    {
        StartCoroutine(LoadScene(scene));
    }

    public void Unload(string scene)
    {
        StartCoroutine(UnloadScene(scene));
    }

    private IEnumerator LoadScene(string sceneBuildIndex)
    {
        // Gets scene
        Scene scene = SceneManager.GetSceneByName(sceneBuildIndex);

        // If scene is not loaded (prevents duplicate scenes loading)
        if (!scene.isLoaded)
        {
            // Loads scene and waits for it to load fully
            AsyncOperation loading = SceneManager.LoadSceneAsync(
                sceneBuildIndex,
                LoadSceneMode.Additive
            );
            yield return loading;

            // Sets the active scene to the newly loaded scene
            Scene activeScene = SceneManager.GetSceneByName(sceneBuildIndex);
            SceneManager.SetActiveScene(activeScene);
        }
    }

    private IEnumerator UnloadScene(string scene)
    {
        // Waits till end of frame
        yield return null;

        // Unloads scene
        SceneManager.UnloadSceneAsync(scene);
    }

    private IEnumerator LoadUnloadScene(string sceneToLoad, string sceneToUnload)
    {
        // Waits till end of frame
        yield return null;

        // Unloads scene and waits for unload to finish
        var loading = SceneManager.UnloadSceneAsync(sceneToUnload);
        yield return loading;

        // Loads the scene
        Load(sceneToLoad);
    }
}
