using UnityEngine;
using Zenject;

namespace MorozovSoftware.GameSystem
{
    public class EntitySpawnerAutoInject : IEntitySpawner
    {
        [SerializeField]
        private Transform _parent;

        public EntitySpawnerAutoInject(Transform parent)
        {
            _parent = parent;
        }

        public Entity Spawn(string resource)
        {
            Entity entity = Object.Instantiate(Resources.Load<Entity>(resource), _parent);
            entity.gameObject.AddComponent<ZenAutoInjecter>();
            return entity;
        }
    }
}
