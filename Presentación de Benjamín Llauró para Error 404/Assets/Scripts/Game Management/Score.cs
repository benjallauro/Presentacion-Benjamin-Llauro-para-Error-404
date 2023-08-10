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
        private bool _scoreLocked = false;

        [SerializeField] private int _scoreToWin = 0;
        void Awake()
        {
            instance = this;
            Pool[] ps = GetComponentsInChildren<Pool>();
        }
        #region Public Methods
        public static Score GetInstance()
        {
            if (instance == null)
                instance = FindObjectOfType<Score>();
            return instance;
        }

        public int GetScore() { return _score; }

        public void AddScore(int scoreToAdd)
        {
            if(_scoreLocked) return;
            _score += scoreToAdd;
            scoreChangeEvent.Invoke();
            if (_score >= _scoreToWin)
            {
                winEvent.Invoke();
                LockScore(true);
            }
        }

        public void SubstractScore(int scoreToSubstract)
        {
            if (_scoreLocked) return;
            _score -= scoreToSubstract;
            if (_score < 0)
                _score = 0;
            scoreChangeEvent.Invoke();
        }
        public void SetScoreToWin(int scoreToWin)
        {
            _scoreToWin = scoreToWin;
        }

        public void LockScore(bool scoreLocked) { _scoreLocked = scoreLocked; }
        #endregion
    }
}