using PlayerSystem;

namespace Gameplay
{
    public class PlayerRespawn
    {
        private Player _player;
        private PlayerSpawner _spawner;

        public PlayerRespawn(Player player, PlayerSpawner spawner)
        {
            _player = player;
            _spawner = spawner;

            _player.OnDeath += RespawnPlayer;
        }

        private void RespawnPlayer()
        {
            _spawner.SpawnPlayer();
        }
    }
}