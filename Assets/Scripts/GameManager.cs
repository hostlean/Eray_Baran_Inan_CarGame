using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DefaultExecutionOrder(-1)]
public class GameManager : MonoBehaviour
{
   #region Singleton

   private static GameManager _instance;

   public static GameManager Instance
   {
      get
      {
         if(_instance == null)
            Debug.LogError("Game Manager is Null");
         return _instance;
      }
   }

   #endregion

   public Action OnMoveCars;

   public bool MoveCars { get; set; }
   
   private void Awake()
   {
      _instance = this;
   }

   private void FixedUpdate()
   {
      if (MoveCars)
         OnMoveCars?.Invoke();
   }

   public void StartSameSequence()
   {
      MoveCars = false;
      CarManager.Instance.DestroyActiveCar();
      CarManager.Instance.ResetCars();
      CarManager.Instance.CreateNewCar();
      
   }

   public void StartNextSequence()
   {
      MoveCars = false;
      CarManager.Instance.AddCarAsPreviousCar();
      CarManager.Instance.ResetCars();
      WaypointManager.Instance.IncreaseWaypointIndex();
      CarManager.Instance.CreateNewCar();
   }
}
