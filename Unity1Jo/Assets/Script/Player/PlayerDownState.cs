using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDownState : PlayerState
{
    public PlayerDownState(Player _player, PlayerStateMachine _stateMachine, string _animBoolName) : base(_player, _stateMachine, _animBoolName)
    {
    }

    // code by 동호
    public override void Enter()
    {
        base.Enter(); // 부모의 Enter 함수 실행   

        float time = player.downTime;

        if (player.middlePos != null) // null 이 아닌지 체크 
            player.transform.DOMoveY(player.middlePos.transform.position.y, time).OnComplete(
                () => {
                    // 중앙 위치까지 이동이 끝났으면 downState로 이동 
                    stateMachine.ChangeState(player.bonusDownState);
                }); ;      // 중앙 위치로 이동 
    }
    // code by 동호  
    public override void Exit()
    {
        base.Exit(); // 부모의 Exit 함수 실행 
    }
    // code by 동호
    public override void Update()
    {
        base.Update();  // 부모의 Update 함수 실행 
        player.DestrtoyObject();  

    }
}
