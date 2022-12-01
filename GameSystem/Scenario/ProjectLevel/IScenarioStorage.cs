using System.Collections.Generic;

namespace MorozovSoftware.GameSystem
{
    public interface IScenarioStorage
    {
        void Save(ScenarioData scenario);
        ScenarioData Load(string name);
        void Delete(string name);
        IEnumerable<string> GetNames();
    }
}
