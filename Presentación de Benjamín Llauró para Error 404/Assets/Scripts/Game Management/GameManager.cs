using System;
using UnityEngine;
using UnityEngine.Events;

namespace GameManagement
{
    public class GameManager : MonoBehaviour
    {
        [Serializable] public class CustomEvent : UnityEvent { }
        public CustomEvent winEvent;
        public CustomEvent loseEvent;
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
        }
        public void WinGame()
        {
            currentState = GameStates.win;
            winEvent.Invoke();
        }
        public void LoseGame()
        {
            currentState = GameStates.win;
            loseEvent.Invoke();
        }

    }
}
