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

    [SerializeField] string effectAudioClipPath = "SoundEff_GameEnd";

    public override void Enter()
    {
        base.Enter();
       
        player.CallResultWindow();

        SoundManager.Instance.Clear();
       

        AudioClip effectAudioClip = GameManager.Instance.LoadAudioClip(effectAudioClipPath);
        if (effectAudioClip != null)
            SoundManager.Instance.Play(effectAudioClip, Define.Sound.Effect);

    }

    public override void Update()
    {
        base.Update();
        player.GroundScrollSpeed = 0;

        if (Input.GetKeyDown(KeyCode.Space)) return;
        else { return; }
    }

    public override void Exit()
    {
        base.Exit();

    }

}
