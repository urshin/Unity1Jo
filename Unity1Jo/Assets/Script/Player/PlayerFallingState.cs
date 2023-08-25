using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFallingState : PlayerState
{
    public PlayerFallingState(Player _player, PlayerStateMachine _stateMachine, string _animBoolName) : base(_player, _stateMachine, _animBoolName)
    {

    }

    public override void Enter()
    {
        base.Enter(); // �θ��� Enter �Լ� ���� 
        rb.gravityScale = 1; // �߷��� 1���� �ݵ� 
    }

    public override void Exit()
    {
        base.Exit(); // �θ��� Exit �Լ� ���� 
    }

    public override void Update()
    {
        base.Update();// �θ��� Update �Լ� ���� 
    }
}