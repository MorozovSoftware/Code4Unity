using UnityEngine;

[CreateAssetMenu]
public class StorageConfig : ScriptableObject
{
    [field: SerializeField] public string SaveFolder { get; private set; }
    [field: SerializeField] public string SaveExtension { get; private set; }
    [field: SerializeField] public string ScenarioFolder { get; private set; }
    [field: SerializeField] public string ScenarioExtension { get; private set; }
}
