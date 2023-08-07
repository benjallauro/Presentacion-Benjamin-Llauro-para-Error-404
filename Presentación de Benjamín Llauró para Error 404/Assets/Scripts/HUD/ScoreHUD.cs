using ScoreSystem;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreHUD : MonoBehaviour
{
    [SerializeField] private Score score;
    [SerializeField] private TextMeshProUGUI scoreNumberText;
    public void UpdateScore()
    {
        scoreNumberText.text = score.GetScore().ToString();
    }
}
