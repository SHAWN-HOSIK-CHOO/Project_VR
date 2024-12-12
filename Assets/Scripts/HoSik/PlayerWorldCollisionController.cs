using System;
using System.Collections;
using UnityEngine;
using TMPro;
using Random = UnityEngine.Random;

namespace HoSik
{
    public class PlayerWorldCollisionController : MonoBehaviour
    {
        public TMP_Text debugText;

        [Header("Script when player collided with each")]
        [Header("Randomly selected when many")]
        public string[] npcHitScripts = new string[4];

        public string   bicycleHitScript;
        public string[] obstacleHitScripts = new string[4];
        public string   vehicleHitScript;

        private bool _canShowScript = true;

        private void OnControllerColliderHit(ControllerColliderHit hit)
        {
            GameObject goOther = hit.gameObject;
            if (goOther.CompareTag("Npc"))
            {
                if (!_canShowScript)
                {
                    return;
                }

                StartCoroutine(CoShowText());
            }
            else if (goOther.CompareTag("Bicycle"))
            {
                UIManager.Instance.SetGuideText(bicycleHitScript);
            }
            else if (goOther.CompareTag("Obstacle"))
            {
                int randomIdx = Random.Range(0, 4);
                UIManager.Instance.SetGuideText(obstacleHitScripts[0]);
            }
            else if (goOther.CompareTag("Vehicle"))
            {
                UIManager.Instance.SetGuideText(vehicleHitScript);
            }
        }


        IEnumerator CoShowText()
        {
            _canShowScript = false;
            int randomIdx = Random.Range(0, 4);
            UIManager.Instance.SetGuideText(npcHitScripts[randomIdx]);
            yield return new WaitForSeconds(3.0f);
            _canShowScript = true;
        }
        
    }
}
