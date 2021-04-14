using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraManager : MonoBehaviour
{
   #region Singleton

   private static CameraManager _instance;

   public static CameraManager Instance
   {
      get
      {
         if(_instance == null)
            Debug.LogError("Camera Manager is Null");
         return _instance;
      }
   }

   #endregion

   [SerializeField] private CinemachineVirtualCamera _virtualCamera;

   private void Awake()
   {
      _instance = this;
   }

   public void FollowCar(Transform car)
   {
      _virtualCamera.Follow = car;
   }

   public void RemoveFollowedCar()
   {
      _virtualCamera.Follow = null;
   }
   
}
