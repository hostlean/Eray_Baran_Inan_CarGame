using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationHolder : MonoBehaviour
{
    [SerializeField] private Movement movement;
    
    private int _listIndex;
    
    private List<Quaternion> rotations = new List<Quaternion>();

    private GameManager _gameManager;

    private void Awake()
    {
        _gameManager = GameManager.Instance;
    }

    private void OnEnable()
    {
        _listIndex = 0;
        if (movement.IsActiveVehicle)
            _gameManager.OnMoveCars += AddRotationsToList;
        else
            _gameManager.OnMoveCars += RotateVehicleByList;
    }

    private void OnDisable()
    {
        if (movement.IsActiveVehicle)
            _gameManager.OnMoveCars -= AddRotationsToList;
        else
            _gameManager.OnMoveCars -= RotateVehicleByList;
    }

    private void AddRotationsToList()
    {
        rotations.Add(transform.rotation);
    }
    

    private void RotateVehicleByList()
    {
        if (_listIndex < rotations.Count)
        {
            transform.rotation = rotations[_listIndex];
            _listIndex++;
        }
        else
        {
            CarManager.Instance.DestroyActiveCar();
        }
    }
}
