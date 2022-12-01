namespace MorozovSoftware.GameSystem
{
    public interface IScenarioLauncher
    {
        void Start();
        ScenarioData GetCurrent();
    }
}
