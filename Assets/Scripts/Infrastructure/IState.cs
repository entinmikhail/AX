namespace Game.Infrastructure
{
    /// <summary>
    /// Interface for simple game states.
    /// </summary>
    public interface IState
    {
        void Enter();
        void Exit();
    }
}
