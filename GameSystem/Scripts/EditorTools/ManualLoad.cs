using MorozovSoftware.GameSystem;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using Zenject;

namespace MorozovSoftware.EditorTools
{
    public class ManualLoad : MonoBehaviour
    {
        Storage _storage;
        ILauncher _launcher;
        [SerializeField]
        GameDataType _type;
        [SerializeField]
        string _name = "test";
        [SerializeField]
        string[] _gameData = null;

        [Inject]
        public void Construct(Storage storage, ILauncher launcher)
        {
            _storage = storage;
            _launcher = launcher;
        }

        [ContextMenu("Load")]
        public void Load()
        {
            GetAll();
            if (_gameData.Contains(_name))
            {
                _launcher.Start(SelectedStorage().Get(_name));
            }
            else
            {
                Debug.Log($"Not found {_name}");
            }
        }

        [ContextMenu("GetAll")]
        public void GetAll()
        {
            _gameData = SelectedStorage().GetNames().ToArray();
        }

        private IStorage SelectedStorage()
        {
            return _type == GameDataType.Save ? _storage.Saves : _storage.Scenarios;
        }

        private enum GameDataType
        {
            Save,
            Scenario
        }

#if UNITY_EDITOR
        private void OnValidate()
        {
            if ((Application.IsPlaying(this)) && (_storage != null) && (_launcher != null))
            {
                GetAll();
            }
        }
#endif
    }
}

