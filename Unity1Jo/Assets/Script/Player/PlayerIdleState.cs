using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerIdleState : PlayerState
{
    public PlayerIdleState(Player _player, PlayerStateMachine _stateMachine, string _animBoolName) : base(_player, _stateMachine, _animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void Exit()
    {
        base.Exit();

        //if(점프키누르면)
        //Slide키 누르면
        //Dash아이템 먹으면
        //Gigantic아이템 먹으면
        //죽으면
        //보너스알파벳 모으면
        //맞으면
    }

    public override void Update()
    {
        base.Update();
    }
}
