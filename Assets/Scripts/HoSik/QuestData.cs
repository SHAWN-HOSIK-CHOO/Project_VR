using System;
using UnityEngine;
using TMPro;

namespace HoSik
{
    public class QuestData : MonoBehaviour
    {
        public string     questScript;

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                UIManager.Instance.SetGuideText(questScript);
            }
        }
    }
}
