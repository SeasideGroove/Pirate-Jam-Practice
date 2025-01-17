using MapSystems;

namespace TerminalEvents
{
    public class TerminalEventSystem : MapSubsystem
    {
        public delegate void TerminalEvent();

        public TerminalEvent OnGameOver;
        public TerminalEvent OnReset;

        public void GameOver()
        {
            OnGameOver?.Invoke();
        }

        public void Reset()
        {
            OnReset?.Invoke();
        }
    }
}