using TMPro;
using UnityEngine;

namespace HUD
{
    public class TimeHudText : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI timeText;
        public void UpdateText(float number)
        {
            int min = Mathf.FloorToInt(number / 60);
            int sec = Mathf.FloorToInt(number % 60);
            if(sec < 10 )
                timeText.text = min.ToString() + ":" + "0" + sec.ToString();
            else
                timeText.text = min.ToString() + ":" + sec.ToString();
        }
    }
}