using UnityEngine;
using Zenject;

namespace MorozovSoftware.GameSystem
{
    public class GlobalInstaller : MonoInstaller
    {
        [SerializeField]
        private StorageConfig _storageConfig;

        public override void InstallBindings()
        {
            var scenarioStorage = new AppStorage(_storageConfig.ScenarioFolder, _storageConfig.ScenarioExtension);
            var saveStorage = new AppStorage(_storageConfig.SaveFolder, _storageConfig.SaveExtension);
            Storage storage = new(scenarioStorage, saveStorage);

            Container.Bind<Storage>().FromInstance(storage).AsSingle();
            Container.Bind<ILauncher>().To<Launcher>().FromNew().AsSingle();
        }
    }
}