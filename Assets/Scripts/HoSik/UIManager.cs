using System;
using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.Serialization;

namespace HoSik
{
    public class UIManager : MonoBehaviour
    {
        public GameObject canvasObject;

        private static UIManager _instance = null;
        public static  UIManager Instance => _instance == null ? null : _instance;

        public TMP_Text guideText;

        public GameObject walkingAnimation;

        public GameObject soundAnimation;

        public TMP_Text timerText;

        public RectTransform questUpdateRect;
        public TMP_Text      questUpdateRectText;

        public TMP_Text questInfoText;
        
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
        
        public void SetTimerText(int time)
        {
            timerText.text = time / 60 + "m " + time % 60 + "s";            
        }

        public void SetQuestUpdateRect(string txt)
        {
            questUpdateRectText.text = txt;
            SetQuestInfoText(txt);
            StartCoroutine(CoQuestUpdateAnimation(new Vector3(1.0f, 1.0f, 1.0f), new Vector3(2.5f, 2.5f, 1.0f), 2.5f));
        }

        public void SetQuestInfoText(string txt)
        {
            questInfoText.text = txt;
        }

        public void InitializeUIForEachScene(ESceneType sceneType)
        {
            questUpdateRect.gameObject.SetActive(false);
            
            switch (sceneType)
            {
                case ESceneType.Intro:
                    break;
                case ESceneType.Home:
                    break;
                case ESceneType.Road:
                    soundAnimation.SetActive(false);
                    walkingAnimation.SetActive(false);
                    break;
                case ESceneType.Bus:
                    soundAnimation.SetActive(true);
                    walkingAnimation.SetActive(false);
                    break;
                default:
                    Debug.Log("Invalid Scene Name");
                    break;
            }
        }

        IEnumerator CoQuestUpdateAnimation(Vector3 startScale, Vector3 endScale,float duration = 2.0f)
        {
            questUpdateRect.gameObject.SetActive(true);
            float halfDuration = duration / 2f; 
            float elapsedTime  = 0f;
            
            while (elapsedTime < halfDuration)
            {
                elapsedTime += Time.deltaTime;
                float t = Mathf.Clamp01(elapsedTime / halfDuration); 
                questUpdateRect.localScale = Vector3.Lerp(startScale, endScale, t);
                yield return null;
            }
            
            elapsedTime = 0f; 
            while (elapsedTime < halfDuration)
            {
                elapsedTime += Time.deltaTime;
                float t = Mathf.Clamp01(elapsedTime / halfDuration); 
                questUpdateRect.localScale = Vector3.Lerp(endScale, startScale, t);
                yield return null;
            }
            
            questUpdateRect.localScale = startScale;
            yield return new WaitForSeconds(0.3f);
            questUpdateRect.gameObject.SetActive(false);
        }
    }
}
