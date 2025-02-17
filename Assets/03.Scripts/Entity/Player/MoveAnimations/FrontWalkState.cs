public class FrontWalkState : IState
{
    private PlayerMovement player;
    private StateMachine stateMachine;

    public FrontWalkState(PlayerControll player, StateMachine stateMachine)
    {
        this.player = player;
        this.stateMachine = stateMachine;
    }

    public void Enter()
    {
        
    }

    public void Exit()
    {
        
    }

    public void Update()
    {
        
    }
}
