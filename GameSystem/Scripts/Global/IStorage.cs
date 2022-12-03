using System.Collections.Generic;

namespace MorozovSoftware.GameSystem
{
    public interface IStorage
    {
        void Add(GameData gameData);
        GameData Get(string name);
        void Delete(string name);
        IEnumerable<string> GetNames();
    }
}
