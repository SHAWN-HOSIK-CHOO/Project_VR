using System;
using System.Collections;
using UnityEngine;

namespace HoSik
{
    public class LocalTimer : MonoBehaviour
    {
        public  float targetTime   = 180f;
        private float _currentTime = 0f;

        private void Start()
        {
            StartTimer();
        }

        private void StartTimer()
        {
            StartCoroutine(CoStartTimer());
        }

        IEnumerator CoStartTimer()
        {
            _currentTime = targetTime;
            UIManager.Instance.SetTimerText(Mathf.CeilToInt(_currentTime)); 

            while (_currentTime > 0f)
            {
                float prevTime = Mathf.CeilToInt(_currentTime); 
                _currentTime -= Time.deltaTime;
                
                if (!Mathf.Approximately(Mathf.CeilToInt(_currentTime), prevTime))
                {
                    UIManager.Instance.SetTimerText(Mathf.CeilToInt(_currentTime));
                }

                yield return null;
            }

            _currentTime = 0f;
            UIManager.Instance.SetTimerText(0); 
        }
    }
}
