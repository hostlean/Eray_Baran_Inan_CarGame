using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DefaultExecutionOrder( -1)]
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
    [SerializeField] private GameObject carPrefab;
    [SerializeField] private int previousCarCount;

    [SerializeField] private List<GameObject> cars = new List<GameObject>();

    public float CarMoveSpeed => carMoveSpeed;

    public float CarTurnSpeed => carTurnSpeed;

    private GameObject _activeCar;

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
        GameObject car = Instantiate(carPrefab, transform.position, Quaternion.identity, transform);
        _activeCar = car;
    }

    public void DestroyActiveCar()
    {
        Destroy(_activeCar);
    }

    public void AddCarAsPreviousCar(GameObject go)
    {
        cars.Add(go);
    }

    public void ResetCars()
    {
        foreach (var car in cars)
        {
            car.SetActive(false);
        }
        ActivatePreviousCars();
    }

    public void ActivatePreviousCars()
    {
        if (cars.Count > 0)
        {
            var difference = cars.Count - previousCarCount;
            var startIndex = difference > 0 ? difference : 0;

            for (int i = startIndex; i < cars.Count; i++)
            {
                cars[i].SetActive(true);
            }
            WaypointManager.Instance.IncreaseWaypointIndex();
        }
      
    }
}
