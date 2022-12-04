using UnityEngine;
using Zenject;

namespace MorozovSoftware.GameSystem
{
    public class SceneInstaller : MonoInstaller
    {
        [SerializeField]
        private Scenario _scenario;
        private Storage _storage;

        [Inject]
        public void Constructor(Storage storage)
        {
            _storage = storage;
        }

        public override void InstallBindings()
        {
            var entitySpawner = new EntitySpawner(_scenario.transform, Container);
            var saver = new Saver(_storage.Saves, _scenario);

            Container.Bind<ISaver>().To<Saver>().FromInstance(saver).AsSingle();
            Container.Bind<IEntitySpawner>().To<EntitySpawner>().FromInstance(entitySpawner).AsSingle();
            Container.Bind<IScenario>().To<Scenario>().FromInstance(_scenario).AsSingle();
        }
    }
}