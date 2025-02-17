using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerState : IState
{  
    protected PlayerControll player;
    protected StateMachine stateMachine;

    public string AnimBoolName { get; set; }

    public PlayerState(PlayerControll player, StateMachine stateMachine, string AnimationBoolName)
    {
        this.player = player;
        this.stateMachine = stateMachine;
        AnimBoolName = AnimationBoolName;
    }

    public virtual void Enter()
    {
        player.animator.SetBool(AnimBoolName, true);
    }

    public virtual void Update()
    {
        if (player.movement.moveDir.y < 0f)
            stateMachine.ChangeState(player.frontWalkState);
        else if (player.movement.moveDir.y > 0f)
            stateMachine.ChangeState(player.backWalkState);
        else if (player.movement.moveDir.x != 0f)
            stateMachine.ChangeState(player.sideWalkState);
    }

    public virtual void Exit()
    {
        player.animator.SetBool(AnimBoolName, false);
    }
}
