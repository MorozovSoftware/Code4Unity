using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using UnityEngine;

namespace MorozovSoftware.GameSystem
{
    public class Entity : MonoBehaviour, IData
    {
        [SerializeField]
        private string _resource;
        public string Resource => _resource;

        [ContextMenu("update resource path")]
        private void UpdatePath()
        {
            _resource = PathTools.GetResourcePath(this);
        }

        public object GetData()
        {
            var data = new Data();
            foreach (var component in GetComponents<IData>())
            {
                if (component != this)
                {
                    data.components[component.GetType().Name] = component.GetData();
                }
            }
            return data;
        }

        public void SetData(JObject data)
        {
            var save = data.ToObject<Data>();
            foreach (var component in GetComponents<IData>())
            {
                if (save.components.TryGetValue(component.GetType().Name, out object componentData))
                {
                    component.SetData((JObject)componentData);
                }
            }
        }

        [System.Serializable]
        private class Data
        {
            public Dictionary<string, object> components = new();
        }
    }
}
