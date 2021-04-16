using System.Collections.Generic;
using UnityEngine;

public class RotationHolder : MonoBehaviour
{
    [SerializeField] private Movement movement;
    
    private int _listIndex;
    
    private List<Quaternion> rotations = new List<Quaternion>();

    private GameManager _gameManager;

    public bool OnTarget { get; set; }

    private void Awake()
    {
        _gameManager = GameManager.Instance;
    }

    private void OnEnable()
    {
        OnTarget = false;
        _listIndex = 0;
        if (movement.IsActiveVehicle)
            _gameManager.OnMoveCars += AddRotationsToList;
        else
            _gameManager.OnMoveCars += RotateVehicleByList;
    }

    private void OnDisable()
    {
        UnsubscribeMethods();
    }

    private void AddRotationsToList()
    {
        rotations.Add(transform.rotation);
    }
    

    private void RotateVehicleByList()
    {
        transform.rotation = rotations[_listIndex];
        _listIndex++;
    }

    public void UnsubscribeMethods()
    {
        if (movement.IsActiveVehicle)
            _gameManager.OnMoveCars -= AddRotationsToList;
        else
            _gameManager.OnMoveCars -= RotateVehicleByList;
    }
}
