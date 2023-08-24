using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHighState : PlayerState
{
    public PlayerHighState(Player _player, PlayerStateMachine _stateMachine, string _animBoolName) : base(_player, _stateMachine, _animBoolName)
    {

    }

    // code by 동호
    public override void Enter()
    {
        base.Enter();

        if (player.topPos != null)
            player.transform.DOMoveY(player.topPos.transform.position.y, player.topTime).OnComplete(
                () => {
                    // 최대 위치까지 이동이 끝났으면 downState로 이동 
                    stateMachine.ChangeState(player.downState);
                });
    }
    // code by 동호
    public override void Exit()
    {
        base.Exit();
    }
    // code by 동호
    public override void Update()
    {
        base.Update();
    }
}
