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
        _instance = this;
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

    public void LoadLevel1()
    {
        SceneManager.LoadScene(2);
    }

    public void LoadLevel2()
    {
        SceneManager.LoadScene(3);
    }

    public void LoadLevel3()
    {
        SceneManager.LoadScene(4);
    }
    
    public void LoadLevel4()
    {
        SceneManager.LoadScene(5);
    }
}
