using Gameplay;

namespace LevelSystem
{
    public class LevelSwitchManager
    {
        public LevelSwitchManager(LevelFinisher levelFinisher, LevelSwitcher levelSwitcher, PlayerSpawner playerSpawner)
        {
            levelFinisher.OnLevelFinished += levelSwitcher.CreateNextLevel;
            levelFinisher.OnLevelFinished += playerSpawner.SpawnPlayer;
        }
    }
}