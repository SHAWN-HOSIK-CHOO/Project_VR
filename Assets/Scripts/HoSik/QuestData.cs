using System;
using System.Collections;
using UnityEngine;
using TMPro;

namespace HoSik
{
    public class QuestData : MonoBehaviour
    {
        public ESceneType sceneType;
        public int        questID;
        public string     questScript;
        public string     questGuideScript;

        public LocalTimer timer;

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                StartQuest(questID);
                UIManager.Instance.SetQuestUpdateRect(questScript);
                UIManager.Instance.SetGuideUpdateRect(questGuideScript);
            }
        }

        private void StartQuest(int id)
        {
            if (id == 0)
            {
                StartCoroutine(CoQuest0Timer());
            }
            else if (id == 1)
            {
                
            }
            else if (id == 2)
            {
                
            }
            else if (id == 3)
            {
                InteractionManager.Instance.hasReachedBusStation = true;
                //TODO: Load Scene
            }
        }

        IEnumerator CoQuest0Timer()
        {
            timer.StartTimer();
            while (!timer.isTimeOver)
            {

                yield return null;
            }

            if (!InteractionManager.Instance.hasReachedBusStation)
            {
                UIManager.Instance.SetGuideUpdateRect("나 : 버스를 놓져버렸다");
                UIManager.Instance.SetQuestUpdateRect("목표 실패");
                InteractionManager.Instance.TeleportCharacter();
            }
        }
    }
}
