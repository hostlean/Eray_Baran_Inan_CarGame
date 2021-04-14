using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    #region Singleton

    private static SceneLoader _instance;

    public static SceneLoader Instance
    {
        get
        {
            if(_instance == null)
                Debug.LogError("Scene Loader is Null");
            return _instance;
        }
    }

    #endregion
    
    private void Awake()
    {
        if(_instance != null)
            Destroy(gameObject);
        else
            _instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void LoadLevelSelection()
    {
        SceneManager.LoadScene(1);
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void LoadSameScene()
    {
        int activeSceneIndex = SceneManager.GetActiveScene().buildIndex;

        SceneManager.LoadScene(activeSceneIndex);
    }

    public void LoadNextScene()
    {
        int activeSceneIndex = SceneManager.GetActiveScene().buildIndex;
        
        if(SceneManager.sceneCount > activeSceneIndex + 1) 
            SceneManager.LoadScene(activeSceneIndex + 1);
        else 
            LoadMainMenu();
    }
}
