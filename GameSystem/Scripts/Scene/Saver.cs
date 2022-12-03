using MorozovSoftware.GameSystem;
using UnityEngine.SceneManagement;

namespace MorozovSoftware
{
    public class Saver : ISaver
    {
        private readonly IStorage _storage;
        private readonly IScenario _scenario;

        public Saver(IStorage storage, IScenario scenario)
        {
            _storage = storage;
            _scenario = scenario;
        }

        public void Save(string name)
        {
            GameData gameData = new()
            {
                name = name,
                map = SceneManager.GetActiveScene().name,
                data = _scenario.GetData()
            };
            _storage.Add(gameData);
        }
    }
}