using System;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;
using System.Collections;
using UnityEngine.SceneManagement;

namespace HoSik
{
   public enum EInteractionType
   {
      None,
      Haptic,
      Count
   }

   public enum ESceneType
   {
      Intro,
      Road,
      Bus,
      Home,
      Count
   }
   
   public class InteractionManager : MonoBehaviour
   {
      private static InteractionManager _instance = null;
      public static  InteractionManager Instance => _instance == null ? null : _instance;

      private void Awake()
      {
         if (_instance == null)
         {
            _instance = this;
            DontDestroyOnLoad(this.gameObject);
         }
         else
         {
            Destroy(this.gameObject);
         }
      }

      [Header("Controllers")] 
      public XRBaseController rightController;
      public XRBaseController leftController;

      public EInteractionType   currentInteractionType   = EInteractionType.None;
      public ESceneType         currentSceneType         = ESceneType.Intro;
      public ETrafficLightState currentTrafficLightState = ETrafficLightState.Green;


      private void Update()
      {
         if (Input.GetKeyDown(KeyCode.Alpha1))
         {
            SceneManager.LoadScene("Scene3");
         }
      }
   }
}