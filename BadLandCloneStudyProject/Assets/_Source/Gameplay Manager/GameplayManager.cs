using Player;
using UnityEngine;

namespace Gameplay
{
    public class GameplayManager : MonoBehaviour
    {
        [SerializeField] private Death playerDeath;

        [SerializeField] private PlayerSpawner spawner;

        private void Awake()
        {
            playerDeath.OnDeath += RespawnPlayer;
        }

        private void Start()
        {
            spawner.SpawnPlayer();
        }

        private void RespawnPlayer()
        {
            spawner.SpawnPlayer();
        }
    }
}