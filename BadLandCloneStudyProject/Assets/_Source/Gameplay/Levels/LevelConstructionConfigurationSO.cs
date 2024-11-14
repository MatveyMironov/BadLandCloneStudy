using System.Collections.Generic;
using UnityEngine;

namespace LevelSystem
{
    [CreateAssetMenu(fileName = "NewLevelConstructionConfiguration", menuName = "Level Construction Configuration")]
    public class LevelConstructionConfigurationSO : ScriptableObject
    {
        [SerializeField] private LevelFragment[] levelFragments;
        [SerializeField] private LevelFragment startFragment;
        [SerializeField] private LevelFragment finishFragment;
        [SerializeField] private int firstLevelSize;

        public LevelFragment[] LevelFragments { get { return levelFragments; } }
        public LevelFragment StartFragment { get => startFragment; }
        public LevelFragment FinishFragment { get => finishFragment; }
        public int FirstLevelSize { get => firstLevelSize; }
    }
}