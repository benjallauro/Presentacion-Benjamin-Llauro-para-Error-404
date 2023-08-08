using ScoreSystem;
using TMPro;
using UnityEngine;

namespace HUD
{
    public class ScoreHUD : MonoBehaviour
    {
        
        [SerializeField] private TextMeshProUGUI scoreNumberText;
        public void UpdateScore()
        {
            scoreNumberText.text = Score.GetInstance().GetScore().ToString();
        }
    }
}