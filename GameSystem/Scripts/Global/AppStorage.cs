using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

namespace MorozovSoftware.GameSystem
{
    public class AppStorage : IStorage
    {
        private readonly string _directory;
        private readonly string _extension;

        public AppStorage(string directory, string extension)
        {
            _directory = Path.Combine(PathTools.DataPath(), PathTools.CorrectSlash(directory, PathTools.Style.System));
            _extension = extension;
            if (!Directory.Exists(_directory))
            {
                Directory.CreateDirectory(_directory);
            }
        }

        public void Add(GameData gameData)
        {
            var filepath = Filepath(gameData.name);
            Debug.Log($"Saving {filepath}");
            try
            {
                if (File.Exists(filepath))
                {
                    File.Delete(filepath);
                }
                using FileStream stream = File.Create(filepath);
                stream.Close();
                File.WriteAllText(filepath, JsonConvert.SerializeObject(gameData));
            }
            catch (Exception e)
            {
                Debug.LogError(e);
                throw e;
            }
        }

        public GameData Get(string name)
        {
            var filepath = Filepath(name);
            Debug.Log($"Load {filepath}");
            try
            {
                return JsonConvert.DeserializeObject<GameData>(File.ReadAllText(filepath));
            }
            catch (Exception e)
            {
                Debug.LogError(e);
                throw e;
            }
        }

        public void Delete(string key)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<string> GetNames()
        {
            var names = Directory.GetFiles(_directory, $"*.{_extension}");
            for (int i = 0; i < names.Length; i++)
            {
                names[i] = Path.GetFileNameWithoutExtension(names[i]);
            }
            return names;
        }

        private string Filepath(string filename)
        {
            return Path.ChangeExtension(Path.Combine(_directory, filename), _extension);
        }
    }
}
