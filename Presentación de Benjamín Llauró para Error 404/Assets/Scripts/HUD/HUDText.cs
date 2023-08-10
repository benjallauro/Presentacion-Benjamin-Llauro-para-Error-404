using TMPro;
using UnityEngine;

namespace HUD
{
    public class HUDText : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI timeText;
        public void UpdateText(int number)
        {
            timeText.text = number.ToString();
        }
    }
}