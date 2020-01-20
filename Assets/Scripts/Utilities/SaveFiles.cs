using System.IO;
using UnityEditor;
using Newtonsoft.Json;

namespace LarsPack.Utils
{
    public class SaveFiles
    {
        private readonly string m_SavePath;
        private readonly string m_FileName;
        private readonly string m_FileExtension;

        private readonly string m_FullPath;

        /// <summary>
        /// Save file accessor
        /// </summary>
        /// <param name="_savePath"> The path where the file will be put </param>
        /// <param name="_fileName"> File name </param>
        /// <param name="_fileExtension"> File extension </param>
        public SaveFiles(string _savePath, string _fileName = "Untitled", string _fileExtension = ".json")
        {
            // Initialize the save data path and file
            m_SavePath = _savePath;
            m_FileName = _fileName;
            m_FileExtension = _fileExtension;

            m_FullPath = m_SavePath + "/" + m_FileName + m_FileExtension;
        }

        /// <summary>
        /// Save the data
        /// </summary>
        /// <typeparam name="T"> Struct type </typeparam>
        /// <param name="_struct"> Struct name </param>
        public void Save<T>(T _struct) where T : struct
        {
            // Create a new file when there is non existing
            if (!File.Exists(m_SavePath + "/" + m_FileName + m_FileExtension))
            {
                File.Create(m_SavePath + "/" + m_FileName + m_FileExtension);
                AssetDatabase.Refresh();
            }

            // Convert the data to json
            string _json = JsonConvert.SerializeObject(_struct);
            File.WriteAllText(m_FullPath, _json);
        }

        /// <summary>
        /// Load the data
        /// </summary>
        /// <typeparam name="T"> Struct type </typeparam>
        /// <param name="_struct"> Struct name </param>
        /// <returns> Loaded data </returns>
        public T Load<T>(T _struct) where T : struct
        {
            // Return default if there is no file, or if the file is empty
            if (!File.Exists(m_FullPath) || m_FullPath.Length < 0)
            {
                return default;
            }

            // Read and deserialze the json data
            string _json = File.ReadAllText(m_FullPath);
            _struct = JsonConvert.DeserializeObject<T>(_json);
            // Return the deserialzed data
            return _struct;
        }
    }
}
