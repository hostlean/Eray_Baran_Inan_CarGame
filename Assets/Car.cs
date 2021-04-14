using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : MonoBehaviour
{
    [SerializeField] private Movement movement;
    [SerializeField] private MeshRenderer meshRenderer;
    [SerializeField] private Material purpleCar;
    

    private void OnDisable()
    {
        if(movement.IsActiveVehicle)
            meshRenderer.material = purpleCar;
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other == movement.EndPoint.GetComponent<Collider>())
        {
            CarManager carManager = CarManager.Instance;
            GameManager.Instance.MoveCars = false;
            movement.EndPoint.SetActive(false);
            carManager.AddCarAsPreviousCar(gameObject);
            carManager.ResetCars();
            carManager.CreateNewCar();
        }

        if (other)
        {
            //CarManager.Instance.DestroyActiveCar();
        }
    }
}
