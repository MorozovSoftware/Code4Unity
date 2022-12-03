namespace MorozovSoftware.GameSystem
{
    public class Storage
    {
        public IStorage Scenarios { get; }
        public IStorage Saves { get; }

        public Storage(IStorage scenarioStorage, IStorage saveStorage)
        {
            Scenarios = scenarioStorage;
            Saves = saveStorage;
        }
    }
}