using MapSystems;
using TerminalEvents;
using UnityEngine;

namespace UI
{
    public class GameOverMenu : MonoBehaviour
    {
        private void Start()
        {
            var terminalEvents = MapSystem.FindOrRegister<TerminalEventSystem>();
            terminalEvents.OnGameOver += OnGameOver;
            terminalEvents.OnReset += OnReset;
            gameObject.SetActive(false);
        }

        private void OnGameOver()
        {
            gameObject.SetActive(true);
        }

        private void OnReset()
        {
            gameObject.SetActive(false);
        }
    }
}