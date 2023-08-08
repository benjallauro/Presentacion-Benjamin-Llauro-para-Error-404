using ScoreSystem;
using TMPro;
using UnityEngine;

namespace HUD
{
    public class ScoreHUD : MonoBehaviour
    {
        [SerializeField] private Score score;
        [SerializeField] private TextMeshProUGUI scoreNumberText;
        public void UpdateScore()
        {
            scoreNumberText.text = score.GetScore().ToString();
        }
    }
}