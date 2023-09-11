using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGiganticState : PlayerState
{
    public PlayerGiganticState(Player _player, PlayerStateMachine _stateMachine, string _animBoolName) : base(_player, _stateMachine, _animBoolName)
    {
    }

    public override void AnimationFinishTrigger()
    {
        base.AnimationFinishTrigger();
    }

    public override void Enter()
    {
        base.Enter();
        //  GameObject.FindGameObjectWithTag("Player").transform.localScale =new Vector3(3, 3, 0);

    }

    public override void Exit()
    {
        base.Exit();
        //GameObject.FindGameObjectWithTag("Player").transform.localScale = new Vector3(1, 1, 0);
        if (player.isGigantic || (player.isGigantic && player.isDashing))
        {
            player.transform.localScale = player.OriginalSize * 2.1f;
        }
    }

    public override void Update()
    {
        base.Update();

        if (player.isBonusTime)
        {

            player.stateMachine.ChangeState(player.highState);
            player.SetActiveShinyEffect(true);
            player.GetShinyEffect()?.GetComponent<ShinyEffect>().StartRotateLightsEffect();
        }
    }
}
