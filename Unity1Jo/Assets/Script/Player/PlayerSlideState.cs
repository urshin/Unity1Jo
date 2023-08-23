using System.Collections;
using System.Collections.Generic;
using Unity.IO.LowLevel.Unsafe;
using UnityEngine;

public class PlayerSlideState : PlayerState
{
    public PlayerSlideState(Player _player, PlayerStateMachine _stateMachine, string _animBoolName) : base(_player, _stateMachine, _animBoolName)
    {
    }


    public override void Enter()
    {
        base.Enter();

        collider.size = new Vector2(1.5f, 0.6f);
        collider.offset -= new Vector2(0, 0.4f);
    }

    public override void Update()
    {
        base.Update();

        if (Input.GetKeyUp(KeyCode.S))
        {
            stateMachine.ChangeState(player.idleState);
        }
    }

    public override void Exit()
    {
        base.Exit();

        collider.size = new Vector2(1.3f, 1.3f);
        collider.offset += new Vector2(0, 0.4f);
    }

    
}
