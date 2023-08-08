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
        public CustomEvent winEvent;
        public CustomEvent loseEvent;
        private ReverseTimer timer;
        private void Awake()
        {
            timer = new ReverseTimer();
            timer.SetTimer(fullGameTimeSeconds);
        }
        private void Start()
        {
            StartGame();
        }
        enum GameStates
        {
            playing,
            win,
            lost
        }
        GameStates currentState = GameStates.playing;
        public void StartGame()
        {
            currentState = GameStates.playing;
            timer.StopAndReset();
            timer.Start();
        }
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
        private void Update()
        {
            if(timer.Update(Time.deltaTime) && currentState == GameStates.playing)
            {
                LoseGame();
            }
            if(currentState == GameStates.playing)
                timeText.UpdateText((int)timer.GetCurrentTime());
        }
    }
}