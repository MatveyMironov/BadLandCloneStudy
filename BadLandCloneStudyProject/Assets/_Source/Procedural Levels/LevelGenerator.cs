using UnityEngine;

namespace LevelSystem
{
    public class LevelGenerator : MonoBehaviour
    {
        [SerializeField] private LevelFragment[] levelFragmentPrefabs;
        [SerializeField] private LevelFragment levelStartPrefab;
        [SerializeField] private LevelFragment levelFinishPrefab;

        [Space]
        [SerializeField] private Transform levelRoute;
        [SerializeField] private int levelSize;

        private Transform _previousFragmentEnd;

        private void Start()
        {
            GenerateLevel();
        }

        public void GenerateLevel()
        {
            LevelFragment levelStart = Instantiate(levelStartPrefab, levelRoute);
            _previousFragmentEnd = levelStart.FragmentEnd;

            for (int i = 0; i < levelSize; i++)
            {
                CreateLevelFragment();
            }

            LevelFragment levelFinish = Instantiate(levelFinishPrefab, levelRoute);
            levelFinish.transform.position = _previousFragmentEnd.position;
        }

        private void CreateLevelFragment()
        {
            int levelFragmentIndex = Random.Range(0, levelFragmentPrefabs.Length);
            LevelFragment levelFragmentPrefab = levelFragmentPrefabs[levelFragmentIndex];
            LevelFragment levelFragment = Instantiate(levelFragmentPrefab, levelRoute);
            levelFragment.transform.position = _previousFragmentEnd.position;
            _previousFragmentEnd = levelFragment.FragmentEnd;
        }
    }
}