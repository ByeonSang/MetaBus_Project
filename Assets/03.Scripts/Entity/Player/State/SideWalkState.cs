public class SideWalkState : PlayerState
{
    public SideWalkState(PlayerControll player, StateMachine stateMachine, string AnimationBoolName) : base(player, stateMachine, AnimationBoolName)
    {
    }

    public override void Update()
    {
        if (player.movement.moveDir.x > 0f)
            player.spriteRenderer.flipX = false;
        else if(player.movement.moveDir.x < 0f)
            player.spriteRenderer.flipX = true;

        if (player.movement.moveDir.magnitude == 0)
            stateMachine.ChangeState(player.sideIdleState);

        base.Update();
    }
}
