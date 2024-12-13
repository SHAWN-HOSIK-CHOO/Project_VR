using System;
using UnityEngine;
using TMPro;

namespace HoSik
{
    public class QuestData : MonoBehaviour
    {
        public ESceneType sceneType;
        public string     questScript;
        public string     questGuideScript;

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                UIManager.Instance.SetQuestUpdateRect(questScript);
                UIManager.Instance.SetGuideText(questGuideScript);
            }
        }
    }
}
