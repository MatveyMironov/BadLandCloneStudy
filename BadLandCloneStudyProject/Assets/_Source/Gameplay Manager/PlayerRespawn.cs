using Player;

namespace Gameplay
{
    public class PlayerRespawn
    {
        private Death _playerDeath;
        private PlayerSpawner _spawner;

        public PlayerRespawn(Death playerDeath, PlayerSpawner spawner)
        {
            _playerDeath = playerDeath;
            _spawner = spawner;

            _playerDeath.OnDeath += RespawnPlayer;
        }

        private void RespawnPlayer()
        {
            _spawner.SpawnPlayer();
        }
    }
}