public class BackWalkState : PlayerState
{
    public BackWalkState(PlayerControll player, StateMachine stateMachine, string AnimationBoolName) : base(player, stateMachine, AnimationBoolName)
    {
    }

    public override void Update()
    {
        if (player.movement.moveDir.magnitude == 0)
            stateMachine.ChangeState(player.backIdleState);

        base.Update();
    }
}
