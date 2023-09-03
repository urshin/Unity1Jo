using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class PlayerDeathState : PlayerState
{
    public PlayerDeathState(Player _player, PlayerStateMachine _stateMachine, string _animBoolName) : base(_player, _stateMachine, _animBoolName)
    {
    }
    
    public override void Enter()
    {
        base.Enter();
        player.GroundScrollSpeed = 0;
        player.CallResultWindow();


    }

    public override void Update()
    {
        base.Update();

        if (Input.GetKeyDown(KeyCode.Space)) return;
        else { return; }
    }

    public override void Exit()
    {
        base.Exit();
    }
   
    
   
}
