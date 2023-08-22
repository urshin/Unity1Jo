using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDashState : PlayerState
{
    public PlayerDashState(Player _player, PlayerStateMachine _stateMachine, string _animBoolName) : base(_player, _stateMachine, _animBoolName)
    {
    }

    public override void AnimationFinishTrigger()
    {
        base.AnimationFinishTrigger();
    }

    public override void Enter()
    {
        base.Enter();
        //GameObject.FindGameObjectWithTag("Player").transform.position += new Vector3(3 * Time.deltaTime, 0, 0);
    }

    public override void Exit()
    {
        base.Exit();
        //GameObject.FindGameObjectWithTag("Player").transform.position += new Vector3(-3 * Time.deltaTime, 0, 0);
    }

    public override void Update()
    {
        base.Update();
    }
}
