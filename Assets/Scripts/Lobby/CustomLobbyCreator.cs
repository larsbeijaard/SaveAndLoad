using UnityEngine;
using LarsPack.Utils;

namespace Game.Lobby
{
    public class CustomLobbyCreator : MonoBehaviour
    {
        [Header("Custom Lobby Data")]
        [SerializeField] private OptionScaler m_PlayerScaler;
        [SerializeField] private OptionScaler m_EnemyScaler;

        [Header("Difficulty Data")]
        [SerializeField] private OptionScaler m_DifficultyScaler;

        // Save file instances
        private SaveFiles m_LobbyDataFile;
        private SaveFiles m_DifficultyDataFile;

        private CustomLobbyData m_CustomLobbyData;
        private DifficultyData m_DifficultyData;

        private void Awake()
        {
            InitCustomLobbyData();
            InitDifficultyData();
        }

        /// <summary>
        /// Button event
        /// </summary>
        public void BTN_SaveData()
        {
            // Update the score value
            m_CustomLobbyData.PlayerLimit = m_PlayerScaler.scaleValue;
            m_CustomLobbyData.EnemyLimit = m_EnemyScaler.scaleValue;
            m_DifficultyData.Difficulty = m_DifficultyScaler.scaleValue;

            // Save the data
            m_LobbyDataFile.Save(m_CustomLobbyData);
            m_DifficultyDataFile.Save(m_DifficultyData);
        }

        /// <summary>
        /// Button event
        /// </summary>
        public void BTN_LoadData()
        {
            // Load the data
            m_CustomLobbyData = m_LobbyDataFile.Load(m_CustomLobbyData);
            m_DifficultyData = m_DifficultyDataFile.Load(m_DifficultyData);

            // Set the loaded data
            m_PlayerScaler.scaleValue = m_CustomLobbyData.PlayerLimit;
            m_EnemyScaler.scaleValue = m_CustomLobbyData.EnemyLimit;
            m_DifficultyScaler.scaleValue = m_DifficultyData.Difficulty;

            // Update the ingame UI
            m_PlayerScaler.UpdateText();
            m_EnemyScaler.UpdateText();
            m_DifficultyScaler.UpdateText();
        }

        /// <summary>
        /// Initialize the custom lobby data
        /// </summary>
        private void InitCustomLobbyData()
        {
            // Set the save file instance
            m_LobbyDataFile = new SaveFiles(Application.dataPath, "LobbyData", ".json");

            // Create a new CustomLobbyData instance
            m_CustomLobbyData = new CustomLobbyData()
            {
                PlayerLimit = m_PlayerScaler.scaleValue,
                EnemyLimit = m_EnemyScaler.scaleValue
            };
        }

        /// <summary>
        /// Initialize the difficulty
        /// </summary>
        private void InitDifficultyData()
        {
            // Set the save file instance
            m_DifficultyDataFile = new SaveFiles(Application.dataPath, "DifficultyData", ".json");

            // Create a new CustomLobbyData instance
            m_DifficultyData = new DifficultyData()
            {
                Difficulty = m_DifficultyScaler.scaleValue
            };
        }
    }

    public struct CustomLobbyData
    {
        public int PlayerLimit;
        public int EnemyLimit;
    }

    public struct DifficultyData
    {
        public int Difficulty;
    }
}
