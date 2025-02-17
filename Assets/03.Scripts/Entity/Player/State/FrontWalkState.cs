public class FrontWalkState : PlayerState
{
    public FrontWalkState(PlayerControll player, StateMachine stateMachine, string AnimationBoolName) : base(player, stateMachine, AnimationBoolName)
    {
    }

    public override void Update()
    {
        if (player.movement.moveDir.magnitude == 0)
            stateMachine.ChangeState(player.frontIdleState);

        base.Update();
    }
}
