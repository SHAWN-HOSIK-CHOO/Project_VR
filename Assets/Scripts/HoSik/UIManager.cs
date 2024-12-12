using System;
using UnityEngine;
using TMPro;

namespace HoSik
{
    public class UIManager : MonoBehaviour
    {
        public GameObject canvasObject;

        private static UIManager _instance = null;
        public static  UIManager Instance => _instance == null ? null : _instance;

        public TMP_Text guideText;

        public GameObject walkingAnimation;
        
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

        public void SetGuideText(string txt)
        {
            guideText.text = txt;
        }

        public void SetWalkingAnimation(bool flag)
        {
            walkingAnimation.SetActive(flag);
        }
    }
}
