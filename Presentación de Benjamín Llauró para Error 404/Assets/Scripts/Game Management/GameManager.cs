using HUD;
using System;
using Tools;
using UnityEngine;
using UnityEngine.Events;

namespace GameManagement
{
    public class GameManager : MonoBehaviour
    {
        [Serializable] public class CustomEvent : UnityEvent { }
        [SerializeField] private float fullGameTimeSeconds;
        [SerializeField] private HUDText timeText;
        [SerializeField] private  SpawnManager spawnManager;
        public CustomEvent winEvent;
        public CustomEvent loseEvent;
        private ReverseTimer timer;
        enum GameStates
        {
            playing,
            win,
            lost
        }
        GameStates currentState = GameStates.playing;

        #region UnityMethods
        private void Awake()
        {
            timer = new ReverseTimer();
            timer.SetTimer(fullGameTimeSeconds);
        }
        private void Update()
        {
            if (timer.Update(Time.deltaTime) && currentState == GameStates.playing)
            {
                LoseGame();
            }
            if (currentState == GameStates.playing)
                timeText.UpdateText((int)timer.GetCurrentTime());
        }
        private void Start()
        {
            StartGame();
        }
        #endregion
        public void StartGame()
        {
            currentState = GameStates.playing;
            SetDifficulty();
            timer.StopAndReset();
            timer.Start();
            spawnManager.StartSpawning();
        }
        #region Victory/Defeat
        public void WinGame()
        {
            currentState = GameStates.win;
            winEvent.Invoke();
            timer.StopAndReset();
        }
        public void LoseGame()
        {
            currentState = GameStates.lost;
            loseEvent.Invoke();
            timer.StopAndReset();
        }
        #endregion
        public void SetDifficulty()
        {
            spawnManager.SetDifficultyLevel(DifficultyManager.GetInstance().GetSelectedDifficulty());
        }
    }
}