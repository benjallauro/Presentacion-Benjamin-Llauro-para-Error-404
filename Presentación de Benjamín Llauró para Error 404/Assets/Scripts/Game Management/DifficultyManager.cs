using System;
using UnityEngine;
using UnityEngine.Events;

namespace GameManagement
{
    
    public class DifficultyManager : MonoBehaviour
    {
        [SerializeField] private Difficulty[] difficulties;
        [SerializeField] private Difficulty defaultDifficulty;
        private static DifficultyManager instance = null;
        private int _levelSelected;

        private void Awake()
        {
            DontDestroyOnLoad(this.gameObject);
        }
        public static DifficultyManager GetInstance()
        {
            if (instance == null)
                instance = FindObjectOfType<DifficultyManager>();
            return instance;
        }
        public void SetSelectedLevel(int levelSelected) { _levelSelected = levelSelected; }
        public Difficulty GetSelectedDifficulty()
        {
            if (difficulties[_levelSelected] == null)
                return defaultDifficulty;
            else
                return difficulties[_levelSelected];
        }
    }
}