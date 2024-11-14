using System;
using UnityEngine;
using UnityEngine.UI;

namespace Gameplay
{
    public class StartMenu : MonoBehaviour
    {
        [SerializeField] private GameObject menuObject;
        [SerializeField] private Button startButton;

        public event Action OnStartButtonClicked;

        private void Start()
        {
            startButton.onClick.AddListener(InvokeStartEvent);
        }

        public void OpenMenu()
        {
            menuObject.SetActive(true);
        }

        public void CloseMenu()
        {
            menuObject.SetActive(false);
        }

        private void InvokeStartEvent()
        {
            OnStartButtonClicked?.Invoke();
        }
    }
}