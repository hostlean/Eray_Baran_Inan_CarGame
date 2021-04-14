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
        if (other.gameObject == movement.EndPoint)
        {
            movement.EndPoint.SetActive(false);
            GameManager.Instance.StartNextSequence();
        }
        if(movement.IsActiveVehicle && (other.gameObject.CompareTag("Block") || other.gameObject.CompareTag("Car")))
        {
            GameManager.Instance.StartSameSequence();
        }

       
    }
}
