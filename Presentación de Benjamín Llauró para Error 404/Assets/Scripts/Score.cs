using UnityEngine;

namespace ScoreSystem
{
    public class Score : MonoBehaviour
    {
        private int _score = 0;

        public void AddScore(int scoreToAdd) { _score += scoreToAdd; }

        public void SubstractScore(int scoreToSubstract) { _score -= scoreToSubstract; }
    }
}
