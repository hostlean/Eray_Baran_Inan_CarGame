using UnityEngine;

[DefaultExecutionOrder( -1)]
public class WaypointManager : MonoBehaviour
{
    #region Singleton

    private static WaypointManager _instance;

    public static WaypointManager Instance
    {
        get
        {
            if(_instance == null)
                Debug.LogError("Waypoint Manager is Null");
            return _instance;
        }
    }
    

    #endregion
    
    [SerializeField] private Transform[] startPoints;
    [SerializeField] private MeshRenderer[] endPoints;

    public Transform[] StartPoints => startPoints;

    public MeshRenderer[] EndPoints => endPoints;

    private int _index;


    private void Awake()
    {
        _instance = this;
    }


    public void AssignWaypoints(Movement car)
    {
        car.StartPoint = startPoints[_index];
        car.EndPoint = endPoints[_index];
    }

    public void IncreaseWaypointIndex()
    {
        _index += 1;

        if (_index == endPoints.Length)
            SceneLoader.Instance.LoadLevelSelection();
        _index %= startPoints.Length;
    }

}
