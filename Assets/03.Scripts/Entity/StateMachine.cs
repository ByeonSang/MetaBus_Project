using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine : MonoBehaviour
{
    public IState CurrentState { get; private set; }

    public StateMachine()
    {

    }

    public void Initialize()
    {
        
    }

    public void ChangeState(IState nextState)
    {
        if (CurrentState != null)
            CurrentState.Exit();

        CurrentState = nextState;
        nextState.Enter();
    }

    public void Update()
    {
        CurrentState.Update();
    }
}
