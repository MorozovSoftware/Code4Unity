namespace MorozovSoftware.GameSystem
{
    public interface ILauncher
    {
        void Start(GameData gameData);
        GameData GetStarted();
    }
}
