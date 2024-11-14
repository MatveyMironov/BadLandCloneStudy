using System.Collections.Generic;
using UnityEngine;

namespace LevelSystem
{
    [CreateAssetMenu(fileName = "NewLevelList", menuName = "Level List")]
    public class LevelListSO : ScriptableObject
    {
        [SerializeField] private List<LevelSwitcher.LevelConfiguration> levels;
        [SerializeField] private LevelFragment startFragment;
        [SerializeField] private LevelFragment finishFragment;

        public List<LevelSwitcher.LevelConfiguration> Levels { get { return levels; } }
        public LevelFragment StartFragment { get => startFragment; }
        public LevelFragment FinishFragment { get => finishFragment; }
    }
}