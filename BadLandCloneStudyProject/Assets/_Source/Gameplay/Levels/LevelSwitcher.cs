using System;
using System.Collections.Generic;
using UnityEngine;

namespace LevelSystem
{
    public class LevelSwitcher
    {
        private LevelCreator _levelGenerator;
        private List<LevelConfiguration> _levels;
        private LevelFragment _startFrgament;
        private LevelFragment _finishFrgament;
        private Transform _levelFinisher;

        public LevelSwitcher(Transform levelRoute, LevelListSO levelList, Transform levelFinisher)
        {
            _levelGenerator = new(levelRoute);
            _levels = levelList.Levels;
            _startFrgament = levelList.StartFragment;
            _finishFrgament = levelList.FinishFragment;
            _levelFinisher = levelFinisher;
        }

        private int _currentLevel = -1;

        public void CreateNextLevel()
        {
            if (_currentLevel < _levels.Count - 1)
            {
                _currentLevel++;
                CreateNewLevel();
            }
        }

        private void CreateNewLevel()
        {
            _levelGenerator.DeleteLevel();

            int levelSize = _levels[_currentLevel].Size;
            LevelFragment[] availableFragments = _levels[_currentLevel].AvailableFragments;
            _levelGenerator.CreateLevel(levelSize, availableFragments, _startFrgament, _finishFrgament, _levelFinisher);
        }

        [Serializable]
        public struct LevelConfiguration
        {
            [SerializeField] private int fragmentsCount;
            [SerializeField] private LevelFragment[] availableFragments;

            public int Size { get => fragmentsCount; }
            public LevelFragment[] AvailableFragments { get => availableFragments; }
        }
    }
}