using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace MorozovSoftware.GameSystem
{
    public class Scenario : MonoBehaviour, IScenario
    {
        private JObject _data;
        private IEntitySpawner _entitySpawner;

        [Inject]
        public void Consturct(ILauncher launcher, IEntitySpawner entitySpawner)
        {
            _data = (JObject)launcher.GetStarted().data;
            _entitySpawner = entitySpawner;
        }

        private void Start()
        {
            SetData(_data);
        }

        public object GetData()
        {
            var data = new Data();

            foreach (var entity in FindObjectsOfType<Entity>())
            {
                if (!data.entities.ContainsKey(entity.Resource))
                {
                    data.entities[entity.Resource] = new List<object>();
                }
                data.entities[entity.Resource].Add(entity.GetData());
            }
            return data;
        }

        public void SetData(JObject data)
        {
            foreach (var entities in data.ToObject<Data>().entities)
            {
                foreach (var entity in entities.Value)
                {
                    var entityInstance = _entitySpawner.Spawn(entities.Key);
                    entityInstance.SetData((JObject)entity);
                }
            }
        }

        [System.Serializable]
        private class Data
        {
            public Dictionary<string, List<object>> entities = new();
        }
    }
}

