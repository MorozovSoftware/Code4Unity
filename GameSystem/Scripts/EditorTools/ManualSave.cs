using MorozovSoftware.GameSystem;
using UnityEngine;

namespace MorozovSoftware.EditorTools
{
    public class ManualSave : MonoBehaviour
    {
        [SerializeField] private GameDataType _selectType;
        [SerializeField] private string _enterName;

        [SerializeField] private StorageConfig _storageConfig;
        [SerializeField] private Scenario _scenario;

        [ContextMenu("Save")]
        private void Save()
        {
            IStorage storage;
            if (_selectType == GameDataType.Save)
            {
                storage = new AppStorage(_storageConfig.SaveFolder, _storageConfig.SaveExtension);
            }
            else
            {
                storage = new AppStorage(_storageConfig.ScenarioFolder, _storageConfig.ScenarioExtension);
            }
            new Saver(storage, _scenario).Save(_enterName);
        }

        private enum GameDataType
        {
            Save,
            Scenario
        }
    }
}

