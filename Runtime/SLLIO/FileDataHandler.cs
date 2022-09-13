using System;
using System.IO;
using UnityEngine;

namespace SingularityLab.Runtime.SLLIO
{
    public class FileDataHandler<T>
    {
        private string _dataDirPath = string.Empty;
        private string _dataFileName = string.Empty;

        public FileDataHandler(in string dirPath, in string fileName)
        {
            _dataDirPath = dirPath;
            _dataFileName = fileName;
        }

        public T Load()
        {
            string fullPath = Path.Combine(_dataDirPath, _dataFileName);
            T loadedData = default;

            if (File.Exists(fullPath))
            {
                try
                {
                    string dataToLoad = string.Empty;

                    using (var stream = new FileStream(fullPath, FileMode.Open))
                    {
                        using (var reader = new StreamReader(stream))
                        {
                            dataToLoad = reader.ReadToEnd();
                        }
                    }

                    loadedData = JsonUtility.FromJson<T>(dataToLoad);
                }
                catch (Exception e)
                {
#if UNITY_EDITOR
                    Debug.LogError($"Error occured when tryig to load data from file: {fullPath} \n {e}");
#endif
                }
            }

            return loadedData;
        }

        public void Save(T data)
        {
            string fullPath = Path.Combine(_dataDirPath, _dataFileName);

            try
            {
                Directory.CreateDirectory(Path.GetDirectoryName(fullPath));

                string dataToStore = JsonUtility.ToJson(data, true);

                using (var stream = new FileStream(fullPath, FileMode.Create))
                {
                    using (var writer = new StreamWriter(stream))
                    {
                        writer.Write(dataToStore);
                    }
                }
            }
            catch (Exception e)
            {
#if UNITY_EDITOR
                Debug.LogError($"Error occured when trying to save data to file: {fullPath} \n {e}");
#endif
            }
        }
    }
}
