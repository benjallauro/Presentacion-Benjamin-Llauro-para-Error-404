using System;
using UnityEngine;
using UnityEngine.Events;

namespace ScoreSystem
{
    public class Score : MonoBehaviour
    {
        [Serializable] public class CustomEvent : UnityEvent { }
        public CustomEvent customEvent;
        private int _score = 0;

        public int GetScore() { return _score; }

        public void AddScore(int scoreToAdd)
        {
            _score += scoreToAdd;
            customEvent.Invoke();
        }

        public void SubstractScore(int scoreToSubstract)
        {
            _score -= scoreToSubstract;
            customEvent.Invoke();
        }
    }
}