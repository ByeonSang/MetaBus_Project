using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControll : MonoBehaviour
{
    public Animator animator { get; set; }
    public SpriteRenderer spriteRenderer { get; set; }

    public PlayerMovement movement { get; set; }



    #region State
    private StateMachine stateMachine; // 유한상태기계

    public FrontIdleState frontIdleState { get; set; }
    public BackIdleState backIdleState { get; set; }
    public SideIdleState sideIdleState { get; set; }

    public FrontWalkState frontWalkState { get; set; }
    public BackWalkState backWalkState { get; set; }
    public SideWalkState sideWalkState { get; set; }

    #endregion

    private void Awake()
    {
        movement = GetComponent<PlayerMovement>();
        stateMachine = new StateMachine();

        #region StateInitialize

        frontIdleState = new FrontIdleState(this, stateMachine, "IsFrontIdle");
        backIdleState = new BackIdleState(this, stateMachine, "IsBackIdle");
        sideIdleState = new SideIdleState(this, stateMachine, "IsSideIdle");

        frontWalkState = new FrontWalkState(this, stateMachine, "IsFrontWalk");
        backWalkState = new BackWalkState(this, stateMachine, "IsBackWalk");
        sideWalkState = new SideWalkState(this, stateMachine, "IsSideWalk");

        #endregion
    }

    private void Start()
    {
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        animator = GetComponentInChildren<Animator>();
        stateMachine.Initialize(frontIdleState);
    }

    private void Update()
    {
        if (stateMachine.CurrentState != null)
            stateMachine.CurrentState.Update();
    }
}
