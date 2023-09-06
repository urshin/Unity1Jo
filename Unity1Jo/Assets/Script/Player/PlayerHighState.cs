using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.U2D;
using UnityEngine.UI;

public class PlayerHighState : PlayerState
{
   

    public PlayerHighState(Player _player, PlayerStateMachine _stateMachine, string _animBoolName) : base(_player, _stateMachine, _animBoolName)
    {

    }

    // code by 동호
    public override void Enter()
    {
        base.Enter(); // 부모의 Enter 함수 실행 
        player.DestrtoyObject();  

        ingameuiManager.HpDown = false;  

        float time = player.topTime; 

        if (player.topPos != null)
            player.transform.DOMoveY(player.topPos.transform.position.y, time).OnComplete(
                () => {
                    // 최대 위치까지 이동이 끝났으면 downState로 이동
                    EnvironmentManager.Instance.SetActiveInGameEnvironment(false);
                    EnvironmentManager.Instance.SetActiveBonusTimeEnvironment(true);  

                    stateMachine.ChangeState(player.downState);
                });

       // Spawnanager.Instance.GetComponent<Spawnanager>().enabled = false;  
    }
    // code by 동호
    public override void Exit()
    {
        base.Exit(); // 부모의 Exit 함수 실행 
    }
    // code by 동호
    public override void Update()
    {
        base.Update(); // 부모의 Update 함수 실행 
        player.DestrtoyObject();  
    }
}
