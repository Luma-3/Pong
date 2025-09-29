using UnityEngine;
using System.IO;

namespace Manager.Data
{
    public static class DataSaver
    {
        private const string SuffixName = "Data.json";
        
        public static void JsonSaver(object data, string nameFile, bool crypt)
        {
            var filePath = PathFormat(nameFile);
            var jsonData = JsonUtility.ToJson(data);
            if (crypt)
            {
                jsonData = DataEncryptor.Encryptor(jsonData);
            }
            File.WriteAllText(filePath,jsonData);
        }

        public static T JsonLoader<T>(string nameFile, bool crypt)
        {
            var filePath = PathFormat(nameFile);
            var jsonData = File.ReadAllText(filePath);
            if (crypt)
            {
                jsonData = DataEncryptor.Encryptor(jsonData);
            }

            var obj = JsonUtility.FromJson<T>(jsonData);
            return obj;
        }

        public static bool JsonChecker(string nameFile)
        {
            return File.Exists(PathFormat(nameFile));
        }

        private static string PathFormat(string nameFile)
        {
            return Application.persistentDataPath + $"/{nameFile}{SuffixName}";
        }
    }
}