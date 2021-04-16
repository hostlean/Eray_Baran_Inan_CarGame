using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    private static UIManager _instance;

    public static UIManager Instance
    {
        get
        {
            if(_instance == null)
                Debug.LogError("UI Manager is Null");
            return _instance;
        }
    }
    
    [SerializeField] private TextMeshProUGUI text;


    private void Awake()
    {
        _instance = this;
    }

    public void UpdateCount(int i)
    {
        text.text = $"{i.ToString()} / 8";
    }
    
}
