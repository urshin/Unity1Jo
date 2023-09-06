using System.Collections;
using System.Collections.Generic;
using Unity.IO.LowLevel.Unsafe;
using UnityEngine;

public class PlayerSlideState : PlayerState
{
    [SerializeField] string effectAudioClipPath = "Basic_Slide";
    [SerializeField] string effectAudioClipPath1 = "Pancake_Slide";
    [SerializeField] string effectAudioClipPath2 = "Moonlight_Slide";
    public PlayerSlideState(Player _player, PlayerStateMachine _stateMachine, string _animBoolName) : base(_player, _stateMachine, _animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();
        PlayerManager.Instance.SetOriginPlayerPositi2on();

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
        else if (data.id == 101)
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

        collider.size = new Vector2(collider.size.x * 1.15f, collider.size.y / 2.16f);
        //collider.size = new Vector2(1.5f, 0.6f);
        collider.offset = new Vector2(collider.offset.x, collider.offset.y - 0.4f);
        //collider.offset -= new Vector2(0, 0.4f);
    }

    public override void Update()
    {
        base.Update();

        if (Input.GetKeyUp(KeyCode.S))
        {
            stateMachine.ChangeState(player.idleState);
        }
        

        if (player.IsWallDetected() && !player.isDashing && !player.isGigantic)
        {
            stateMachine.ChangeState(player.hitState);
        }

        if (player.isBonusTime)
        {

            player.stateMachine.ChangeState(player.highState);
            player.SetActiveShinyEffect(true);
            player.GetShinyEffect()?.GetComponent<ShinyEffect>().StartRotateLightsEffect();
        }

    }

    public override void Exit()
    {
        base.Exit();

        collider.size = new Vector2(collider.size.x / 1.15f, collider.size.y * 2.16f);
        collider.offset = new Vector2(collider.offset.x, collider.offset.y + 0.4f);
        // collider.offset += new Vector2(0, 0.4f);
    }

    
}
