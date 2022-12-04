using UnityEngine;
using Zenject;

namespace MorozovSoftware.GameSystem
{
    public class EntitySpawner : IEntitySpawner
    {
        [SerializeField]
        private Transform _parent;
        private DiContainer _container;

        public EntitySpawner(Transform parent, DiContainer container)
        {
            _parent = parent;
            _container = container;
        }

        public Entity Spawn(string resource)
        {
            return _container.InstantiatePrefabResource(resource, _parent).GetComponent<Entity>();
        }
    }
}
