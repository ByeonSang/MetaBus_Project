using UnityEngine;

public interface IState
{
    public string AnimBoolName { get; set; }
    public void Enter();
    public void Update();
    public void Exit();
}
