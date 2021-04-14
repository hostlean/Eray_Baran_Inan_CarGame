using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{

    private float _moveSpeed;
    private float _turnSpeed;
    
    public Transform StartPoint { get; set; }
    public GameObject EndPoint { get; set; }


    private GameManager _gameManager;
    private float _moveForward;
    private float _turnInputValue;
    public bool IsActiveVehicle { get; private set; } = true;
    
    private void Awake()
    {
        WaypointManager.Instance.AssignWaypoints(this);
        _gameManager = GameManager.Instance;
    }

    private void OnEnable()
    {
        InputManager.Instance.OnStartTouch += VehicleRotateInput;
        InputManager.Instance.OnEndTouch += VehicleRotateInput;
        
        transform.position = StartPoint.position;
        transform.rotation = StartPoint.rotation;
        
        _moveSpeed = CarManager.Instance.CarMoveSpeed;
        _turnSpeed = CarManager.Instance.CarTurnSpeed;
        
        _gameManager.OnMoveCars += MoveForward;

        
        if(IsActiveVehicle)
        {
            EndPoint.SetActive(true);
            _gameManager.OnMoveCars += RotateVehicle;
        }
    }

    private void OnDisable()
    {
        InputManager.Instance.OnStartTouch -= VehicleRotateInput;
        InputManager.Instance.OnEndTouch -= VehicleRotateInput;

        _gameManager.OnMoveCars -= MoveForward;
        if (IsActiveVehicle)
            _gameManager.OnMoveCars -= RotateVehicle;
        IsActiveVehicle = false;
        gameObject.tag = "Car";
    }


    public void VehicleRotateInput(Vector2 pos, float time)
    {
        if (!GameManager.Instance.MoveCars && pos.x != 0)
        {
            GameManager.Instance.MoveCars = true;
        }
        else
        {
            float halfScreen = Screen.width / 2;
            if (pos.x == 0)
                _turnInputValue = 0;
            else if (pos.x < halfScreen)
                _turnInputValue = -1;
            else if (pos.x > halfScreen)
                _turnInputValue = 1;
        }
    }
    
    private void MoveForward()
    {
        _moveForward = _moveSpeed * Time.fixedDeltaTime;
        transform.Translate(Vector3.forward * _moveForward);
    }

    private void RotateVehicle()
    {
        var rotation = new Vector3(0, _turnSpeed * _turnInputValue * Time.fixedDeltaTime, 0);
        transform.Rotate(rotation);
    }
    
}
