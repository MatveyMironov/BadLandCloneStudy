using System;
using System.Collections.Generic;
using UnityEngine;

namespace LevelSystem
{
    public class LevelSwitcher
    {
        private LevelCreator _levelGenerator;

        private LevelFragment[] _levelFragments;
        private LevelFragment _startFrgament;
        private LevelFragment _finishFrgament;

        private Transform _levelFinisher;

        public LevelSwitcher(Transform levelRoute, LevelConstructionConfigurationSO levelList, Transform levelFinisher)
        {
            _levelGenerator = new(levelRoute);

            _levelFragments = levelList.LevelFragments;
            _startFrgament = levelList.StartFragment;
            _finishFrgament = levelList.FinishFragment;
            _currentLevelSize = levelList.FirstLevelSize;

            _levelFinisher = levelFinisher;
        }

        private int _currentLevel;
        private int _currentLevelSize;

        public void CreateNextLevel()
        {
            if (_currentLevel < _levelFragments.Length - 1)
            {
                CreateNewLevel();
            }

            _currentLevel++;
            _currentLevelSize++;
        }

        private void CreateNewLevel()
        {
            _levelGenerator.DeleteLevel();

            _levelGenerator.CreateLevel(_currentLevelSize, _levelFragments, _startFrgament, _finishFrgament, _levelFinisher);
        }
    }
}