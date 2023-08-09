using System;
using UnityEngine;
using UnityEngine.Events;
using PoolSystem;

namespace ScoreSystem
{
    public class Score : MonoBehaviour
    {
        private static Score instance = null;
        [Serializable] public class CustomEvent : UnityEvent { }
        public CustomEvent scoreChangeEvent;
        public CustomEvent winEvent;
        private int _score = 0;

        [SerializeField] private int _scoreToWin = 0; //won't be serializable in the future

        public static Score GetInstance()
        {
            if (instance == null)
                instance = FindObjectOfType<Score>();
            return instance;
        }
        void Awake()
        {
            instance = this;
            Pool[] ps = GetComponentsInChildren<Pool>();
        }
        public int GetScore() { return _score; }

        public void AddScore(int scoreToAdd)
        {
            _score += scoreToAdd;
            scoreChangeEvent.Invoke();
            if (_score >= _scoreToWin)
                winEvent.Invoke();
        }

        public void SubstractScore(int scoreToSubstract)
        {
            _score -= scoreToSubstract;
            if (_score < 0)
                _score = 0;
            scoreChangeEvent.Invoke();
        }
        public void SetScoreToWin(int scoreToWin)
        {
            _scoreToWin = scoreToWin;
        }
    }
}