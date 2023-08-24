using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeathState : PlayerState
{
    public PlayerDeathState(Player _player, PlayerStateMachine _stateMachine, string _animBoolName) : base(_player, _stateMachine, _animBoolName)
    {
    }
    // code by 동호
    public override void Enter()
    {
        base.Enter();   // 부모의 Enter 함수 실행 
    }
    // code by 동호
    public override void Exit()
    {
        base.Exit();    // 부모의 Exit 함수 실행 
    }
    // code by 동호
    public override void Update()
    {
        base.Update(); // 부모의 Update 함수 실행 
    }
}
