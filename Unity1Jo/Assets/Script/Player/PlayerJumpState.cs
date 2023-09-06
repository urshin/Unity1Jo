using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJumpState : PlayerState
{
    [SerializeField] string effectAudioClipPath = "Basic_Jump";
    [SerializeField] string effectAudioClipPath1 = "PanCake_Jump";
    [SerializeField] string effectAudioClipPath2 = "Moonlight_Jump";
    public PlayerJumpState(Player _player, PlayerStateMachine _stateMachine, string _animBoolName) : base(_player, _stateMachine, _animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();

        //데이터 로드
        HE_DataManager.instance.LoadData();
        MycookiesData data = HE_DataManager.instance.GetMycookiesDatas().Find(cookie => cookie.id == UserDataManager.Instance.GetSelectCookieID());

        //Effect재생
        if (data.id == 100)
        {
            AudioClip effectAudioClip = GameManager.Instance.LoadAudioClip(effectAudioClipPath);
            if (effectAudioClip != null)
                SoundManager.Instance.Play(effectAudioClip, Define.Sound.Effect);
        }
        else if(data.id == 101)
        {
            AudioClip effectAudioClip = GameManager.Instance.LoadAudioClip(effectAudioClipPath1);
            if (effectAudioClip != null)
                SoundManager.Instance.Play(effectAudioClip, Define.Sound.Effect);
        }
        else if (data.id == 102)
        {
            AudioClip effectAudioClip = GameManager.Instance.LoadAudioClip(effectAudioClipPath2);
            if (effectAudioClip != null)
                SoundManager.Instance.Play(effectAudioClip, Define.Sound.Effect);
        }


        Vector2 jumpVec = new Vector2(rb.velocity.x, player.GetJumpPower());
        rb.AddForce(jumpVec, ForceMode2D.Impulse);
    }

    public override void Update()
    {
        base.Update();

        if (Input.GetKeyDown(KeyCode.Space) && !player.IsGroundDetected())
        {
            stateMachine.ChangeState(player.doubleJumpState);
        }

        if (player.IsGroundDetected() && rb.velocity.y == 0)
        {
            stateMachine.ChangeState(player.idleState);
        }

        if (Input.GetKey(KeyCode.S))
        {
            stateMachine.ChangeState(player.slideState);
        }
        

        if (player.IsWallDetected() && !player.isDashing && !player.isGigantic)
        {
            player.stateMachine.ChangeState(player.hitState);  
        }

        if (player.isBonusTime)
        {

            player.stateMachine.ChangeState(player.highState);
            player.SetActiveShinyEffect(true);
            player.GetShinyEffect()?.GetComponent<ShinyEffect>().StartRotateLightsEffect();
        }
        //if (Input.GetKey(KeyCode.S) && player.IsGroundDetected())
        //{
        //    stateMachine.ChangeState(player.slideState);
        //}
        if (player.isDashing || (player.isDashing && player.isGigantic))
        {
            player.GroundScrollSpeed = player.OriginalGroundScrollSpeed * 3;
        }
        if (player.isGigantic || (player.isGigantic && player.isDashing))
        {
            player.transform.localScale = player.OriginalSize * 3;
        }
    }

    public override void Exit()
    {
        base.Exit();
        player.vibrate();
        
    }

}
