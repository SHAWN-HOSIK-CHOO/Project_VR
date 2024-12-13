using System;
using UnityEngine;

namespace HoSik
{
    public class RoadEdgePusher : MonoBehaviour
    {
        public string guideText;
        private void OnControllerColliderHit(ControllerColliderHit hit)
        {
            if (hit.gameObject.CompareTag("Player"))
            {
                UIManager.Instance.SetGuideText(guideText);
            }
        }

        private void OnCollisionEnter(Collision other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                UIManager.Instance.SetGuideText(guideText);
            }
        }
    }
}
