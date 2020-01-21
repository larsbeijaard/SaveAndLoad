using UnityEngine;
using TMPro;

namespace Game.Lobby
{
    public enum ScalerType
    {
        PLAYER_LIMIT,
        ENEMY_LIMIT,
        DIFFICULTY
    }

    public class OptionScaler : MonoBehaviour
    {
        [Header("Scaler Options")]
        public int scaleValue;
        public TextMeshProUGUI correspondingText;
        [SerializeField] private ScalerType m_ScalerType;
        [SerializeField] private int m_MinimumScale;
        [SerializeField] private int m_MaximumScale;

        /// <summary>
        /// This is called when the game load its files
        /// </summary>
        public void UpdateText()
        {
            correspondingText.text = m_ScalerType.ToString() + " " + scaleValue;
        }

        /// <summary>
        /// Button Event
        /// </summary>
        public void BTN_ScaleDown()
        {
            if (scaleValue > m_MinimumScale)
            {
                scaleValue--;
                correspondingText.text = m_ScalerType.ToString() + " " + scaleValue;
            }
        }

        /// <summary>
        /// Button Event
        /// </summary>
        public void BTN_ScaleUp()
        {
            if (scaleValue < m_MaximumScale)
            {
                scaleValue++;
                correspondingText.text = m_ScalerType.ToString() + " " + scaleValue;
            }
        }
    }
}
