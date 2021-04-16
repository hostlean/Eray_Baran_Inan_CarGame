using System.Collections.Generic;
using UnityEngine;

public class CarManager : MonoBehaviour
{

    #region Singleton

    private static CarManager _instance;

    public static CarManager Instance
    {
        get
        {
            if(_instance == null)
                Debug.LogError("Car Manager is Null");
            return _instance;
        }
    }

    #endregion
   
    
    [SerializeField] private float carMoveSpeed;
    [SerializeField] private float carTurnSpeed;
    [SerializeField] private int previousCarCount;
    [SerializeField] private bool showOldTrails;
    [SerializeField] private bool showOldTargets;
    [SerializeField] private bool waitForOldCars;
    [SerializeField] private RotationHolder carPrefab;

    [SerializeField, Tooltip("Default Size is 5")]
    private float carSize = 5;

    [SerializeField] private List<RotationHolder> cars = new List<RotationHolder>();

    private RotationHolder _activeCar;
    public float CarMoveSpeed => carMoveSpeed;

    public float CarTurnSpeed => carTurnSpeed;

    public bool ShowPreviousCarTrails => showOldTrails;

    public bool ShowPreviousCarTargets => showOldTargets;

    public bool WaitForPreviousCars => waitForOldCars;

    public RotationHolder ActiveCar => _activeCar;


    private void Awake()
    {
        _instance = this;
    }

    private void Start()
    {
        CreateNewCar();
    }

    public void CreateNewCar()
    {
        RotationHolder car = Instantiate(carPrefab, transform.position, Quaternion.identity, transform);
        car.gameObject.transform.localScale = new Vector3(carSize, carSize, carSize);
        _activeCar = car;
    }

    public void DestroyActiveCar()
    {
        _activeCar.UnsubscribeMethods();
        _activeCar.gameObject.SetActive(false);
        Destroy(_activeCar);
    }

    public void AddCarAsPreviousCar()
    {
        cars.Add(_activeCar);
    }
    

    public void ResetCars()
    {
        foreach (var car in cars)
        {
            car.gameObject.SetActive(false);
        }
        ActivatePreviousCars();
    }

    public void ActivatePreviousCars()
    {
        if (cars.Count > 0)
        {
            previousCarCount = previousCarCount > 7 ? 7 : previousCarCount;
            previousCarCount = previousCarCount < 0 ? 0 : previousCarCount;
            var difference = cars.Count - previousCarCount;
            var startIndex = difference > 0 ? difference : 0;

            for (int i = startIndex; i < cars.Count; i++)
            {
                cars[i].gameObject.SetActive(true);
            }
        }
    }

    public bool CheckIfAllCarsAtTarget()
    {
        foreach (var car in cars)
        {
            if (!car.OnTarget && car.gameObject.activeSelf)
                return false;
        }

        return true;
    }
}
