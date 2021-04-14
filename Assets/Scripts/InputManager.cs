using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Interactions;

public class InputManager : MonoBehaviour
{
   #region Singleton

   private static InputManager _instance;

   public static InputManager Instance
   {
      get
      {
         if (_instance == null)
         {
            Debug.LogError("Input Manager is null");
            //var go = new GameObject("Input Manager").AddComponent<InputManager>();
         }
         return _instance;
      }
   }

   #endregion

   public Action<Vector2, float> OnStartTouch;
   public Action<Vector2, float> OnEndTouch;

   private InputMaps _inputMaps;

   private void Awake()
   {
      _instance = this;
      _inputMaps = new InputMaps();
   }

   private void OnEnable()
   {
      _inputMaps.Enable();
   }

   private void OnDisable()
   {
      _inputMaps.Disable();
   }

   private void Start()
   {
      _inputMaps.Touch.TouchPress.started += ctx => StartTouch(ctx);
      _inputMaps.Touch.TouchPress.canceled += ctx => EndTouch(ctx);
   }

   public void StartTouch(InputAction.CallbackContext context)
   {
      OnStartTouch?.Invoke(_inputMaps.Touch.TouchPosition.ReadValue<Vector2>(), (float) context.startTime);
   }

   public void EndTouch(InputAction.CallbackContext context)
   {
      OnEndTouch?.Invoke(Vector2.zero, (float) context.time); 
   }
}
