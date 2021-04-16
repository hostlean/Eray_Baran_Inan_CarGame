using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionHolder : MonoBehaviour
{
    [SerializeField] private Movement movement;
    [SerializeField] private TrailRenderer trailRenderer;
    private List<Vector3> _positions = new List<Vector3>();

    private int _listIndex;


    private void OnEnable()
    {
        if (movement.IsActiveVehicle)
           GameManager.Instance.OnMoveCars += AddPositionsToList;
        else
        {
            trailRenderer.enabled = true;
        }
    }

    private void OnDisable()
    {
        _listIndex = 0;
        trailRenderer.enabled = false;
        if (movement.IsActiveVehicle)
            GameManager.Instance.OnMoveCars -= AddPositionsToList;
        gameObject.SetActive(false);
    }

    private void FixedUpdate()
    {
        if (!movement.IsActiveVehicle && !GameManager.Instance.MoveCars)
        {
            MoveThroughFromList();
        }
    }

    private void AddPositionsToList()
    {
        _positions.Add(transform.position);
    }
    
    private void MoveThroughFromList()
    {
        if (_listIndex < _positions.Count)
        {
            if (_listIndex == 2)
                trailRenderer.emitting = true;
            transform.position = _positions[_listIndex];
            _listIndex++;
        }
        else
        {
            trailRenderer.emitting = false;
            _listIndex = 0;
        }
    }
}
