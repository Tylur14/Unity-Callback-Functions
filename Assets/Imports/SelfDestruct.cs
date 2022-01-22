using System;
using System.Collections;
using UnityEngine;

/// <summary>
/// JimJam Utilities
/// Self Destruct
///
/// Features:
/// |-> Remove gameobject after set amount of time after enabled
/// |-> Remove gameobject after current playing animation finishes
///
/// Helpful resources:
/// |-> Find out if animator is playing an animation - https://answers.unity.com/questions/362629/how-can-i-check-if-an-animation-is-being-played-or.html
/// </summary>
namespace JimJam.Utility
{
    public class SelfDestruct : MonoBehaviour
    {
        [SerializeField] private float timer;
        [SerializeField] private bool triggerOnStart;
        private bool countdown;
        private float t;
        private void OnEnable()
        {
            if(triggerOnStart)
                TriggerDestruct();
        }

        private void Update()
        {
            if (!countdown) return;
            if (t > 0)
            {
                t -= Time.deltaTime;
                return;
            }
            this.gameObject.SetActive(false);
        }

        public void TriggerDestruct(float overrideTime)
        {
            t = timer = overrideTime;
            countdown = true;
        }
        
        public void TriggerDestruct()
        {
            t = timer;
            countdown = true;
        }
    }

}
