using UnityEngine;

namespace LevelSystem
{
    public class LevelCreator
    {
        private Transform _levelRoute;

        public LevelCreator(Transform levelRoute)
        {
            _levelRoute = levelRoute;
        }

        private Vector3 _previousFragmentEndPosition;

        public void DeleteLevel()
        {
            foreach (Transform child in _levelRoute)
            {
                GameObject.Destroy(child.gameObject);
            }
        }

        public void CreateLevel(int levelSize, LevelFragment[] availableFragments, LevelFragment levelStartPrefab, LevelFragment levelFinishPrefab, Transform levelFinisher)
        {
            _previousFragmentEndPosition = _levelRoute.position;

            AddFragment(levelStartPrefab);

            for (int i = 0; i < levelSize; i++)
            {
                LevelFragment levelFragmentPrefab = SelectFragment(availableFragments);
                AddFragment(levelFragmentPrefab);
            }

            AddFragment(levelFinishPrefab);
            levelFinisher.position = _previousFragmentEndPosition;
        }

        private LevelFragment SelectFragment(LevelFragment[] levelFragmentPrefabs)
        {
            int levelFragmentIndex = Random.Range(0, levelFragmentPrefabs.Length);
            return levelFragmentPrefabs[levelFragmentIndex];
        }

        private void AddFragment(LevelFragment levelFragmentPrefab)
        {
            LevelFragment levelFragmentInstance = GameObject.Instantiate(levelFragmentPrefab, _levelRoute);
            levelFragmentInstance.transform.position = _previousFragmentEndPosition;
            _previousFragmentEndPosition = levelFragmentInstance.FragmentEnd.position;
        }
    }
}