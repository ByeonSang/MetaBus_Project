public class StateMachine
{
    public IState CurrentState { get; private set; }

    public void Initialize(IState startState)
    {
        CurrentState = startState;
        CurrentState.Enter();
    }

    public void ChangeState(IState nextState)
    {
        if (CurrentState != null)
            CurrentState.Exit();

        CurrentState = nextState;
        nextState.Enter();
    }
}
