using MapSystems;
using TerminalEvents;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    [RequireComponent(typeof(Button))]
    public class ResetButton : MonoBehaviour
    {
        private void Awake()
        {
            var button = GetComponent<Button>();
            button.onClick.AddListener(OnClick);
        }

        private void OnClick()
        {
            var terminalEvents = MapSystem.FindOrRegister<TerminalEventSystem>();
            terminalEvents?.Reset();
        }
    }
}