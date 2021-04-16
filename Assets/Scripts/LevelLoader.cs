using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
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
