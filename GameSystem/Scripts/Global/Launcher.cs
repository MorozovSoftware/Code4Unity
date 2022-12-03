using UnityEngine.SceneManagement;

namespace MorozovSoftware.GameSystem
{
    public class Launcher : ILauncher
    {
        private GameData _gameData;

        public GameData GetStarted()
        {
            return _gameData;
        }

        public void Start(GameData gameData)
        {
            _gameData = gameData;
            SceneManager.LoadScene(_gameData.map);
        }
    }
}
