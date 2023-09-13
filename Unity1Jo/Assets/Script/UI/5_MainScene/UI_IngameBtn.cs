using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UI_IngameBtn : UI_EventBase
{
    [SerializeField] Button Jump;
    [SerializeField] Button Slide;
    [SerializeField] GameObject PausePanel;
    [SerializeField] Button Pause;
    [SerializeField] Button KeepGame;
    [SerializeField] Button ReStart;
    [SerializeField] Button GiveUp;
    [SerializeField] Button BonusJumpBtn;
    [SerializeField] Button BonusSlideBtn;
    bool _buttonPush; // button push flag
    bool isjumping = false; // 점프 유무 플래그
    Player player;
    UI_InGame gameUIManager;

    public bool bonusTimeFinish = false; // 보너스 시간 끝났을 때 체크 (이거는 UIManager에서 보너스타임이 끝났는 지 알아야 할 플래그 변수 )

    [SerializeField] string effectAudioClipPath = "E_ClickBtn";
    private void Start()
    {
        //BonusJump.gameObject.AddUIEvent(ButtonClicked, type : Define.UIEvent.PointerDown);  
        Jump.gameObject.AddUIEvent(JumpButton, type: Define.UIEvent.PointerDown); // 버튼 다운 했을 떄 이벤트 등록 (타입의 기본값 : Define.UIEvent.Click)
        Jump.gameObject.AddUIEvent(JumpButtonUp, type: Define.UIEvent.PointerUp); // 버튼 다운 했을 떄 이벤트 등록 (타입의 기본값 : Define.UIEvent.Click)
        Jump.gameObject.AddUIEvent(DoubleJump, type: Define.UIEvent.PointerDown);
        Jump.gameObject.AddUIEvent(DoubleJumpUP, type: Define.UIEvent.PointerUp);
        Pause.gameObject.AddUIEvent(PauseGame);
        KeepGame.gameObject.AddUIEvent(PauseCancle);
        ReStart.gameObject.AddUIEvent(ReStartDown);
        GiveUp.gameObject.AddUIEvent(GiveUP);

        Slide.gameObject.AddUIEvent(SlideButton, type: Define.UIEvent.PointerDown);
        Slide.gameObject.AddUIEvent(SlideButtonUp, type: Define.UIEvent.PointerUp);

        BonusJumpBtn.gameObject.AddUIEvent(OnButtonDown, type: Define.UIEvent.PointerDown); // 버튼 다운 했을 떄 이벤트 등록 (타입의 기본값 : Define.UIEvent.Click)
        BonusJumpBtn.gameObject.AddUIEvent(OnButtonUp, type: Define.UIEvent.PointerUp); // 버튼 업 했을 떄 이벤트 등록 (타입의 기본값 : Define.UIEvent.Click)

        BonusSlideBtn.gameObject.AddUIEvent(OnButtonDown, type: Define.UIEvent.PointerDown); // 버튼 다운 했을 떄 이벤트 등록 (타입의 기본값 : Define.UIEvent.Click)
        BonusSlideBtn.gameObject.AddUIEvent(OnButtonUp, type: Define.UIEvent.PointerUp); // 버튼 업 했을 떄 이벤트 등록 (타입의 기본값 : Define.UIEvent.Click)

        BonusJumpBtn.gameObject.SetActive(false);
        BonusSlideBtn.gameObject.SetActive(false);

        //GameObject playerObj = PlayerManager.Instance.GetPlayer(); // PlayManager라는 싱글톤 클래스에서 플레이어 게임 오브젝트 얻어옴.
        //if (playerObj == null) // 플레이어 오브젝트가 없으면 리턴 
        //    return;
        GameObject playerObj = GameObject.FindGameObjectWithTag("Player").gameObject;
        if (playerObj == null) // 플레이어 오브젝트가 없으면 리턴 
            return;
        player = playerObj.GetComponent<Player>(); // 플레이어 컴포넌트 가져옴 
        gameUIManager = GetComponent<UI_InGame>();
    }

    void GiveUP(PointerEventData data)
    {
        Time.timeScale = 1;

        //Effect재생
        AudioClip effectAudioClip = GameManager.Instance.LoadAudioClip(effectAudioClipPath);
        if (effectAudioClip != null)
            SoundManager.Instance.Play(effectAudioClip, Define.Sound.Effect);

        SceneManager.LoadScene("ResultScene");
        SoundManager.Instance.Clear();
        SpawnManager.Instance.gameObject.GetComponent<SpawnManager>().enabled = false;

    }

    void ReStartDown(PointerEventData data)
    {
        GameManager.Instance.totalCoin -= GameManager.Instance.currentCoin;
        GameManager.Instance.currentCoin = 0;
        SceneManager.LoadScene("MainScene");
        Time.timeScale = 1;
        player.mapcount = 0;
        player.isMapChange = true;
        SpawnManager.Instance.ChangeJellyPrefab(SpawnManager.Instance.whatjelly[0], SpawnManager.Instance.image0);
        SpawnManager.Instance.ChangeEnemy(SpawnManager.Instance.whatobstacle[0], SpawnManager.Instance.Short0);
        SpawnManager.Instance.ChangeEnemy(SpawnManager.Instance.whatobstacle[1], SpawnManager.Instance.Long0);
        SpawnManager.Instance.ChangeEnemy(SpawnManager.Instance.whatobstacle[2], SpawnManager.Instance.Slide0);
        SpawnManager.Instance.ChangeEnemy(SpawnManager.Instance.whatobstacle[3], SpawnManager.Instance.LongSlide0);

        //Effect재생
        AudioClip effectAudioClip = GameManager.Instance.LoadAudioClip(effectAudioClipPath);
        if (effectAudioClip != null)
            SoundManager.Instance.Play(effectAudioClip, Define.Sound.Effect);

        // BGM을 다시 재생
        SoundManager.Instance.PlayBGM();

        //GameObject Mbonus = GameObject.Find("BonusMap").gameObject;
        //Mbonus.SetActive(false);     
    }
    public void SetButtonPush(bool flag)
    {
        _buttonPush = flag;
    }
    void PauseGame(PointerEventData data)
    {
        _buttonPush = true;
        PausePanel.SetActive(true);
        Time.timeScale = 0;

        SoundManager.Instance.PauseBGM();

        //Effect재생
        AudioClip effectAudioClip = GameManager.Instance.LoadAudioClip(effectAudioClipPath);
        if (effectAudioClip != null)
            SoundManager.Instance.Play(effectAudioClip, Define.Sound.Effect);  
    }

    void PauseCancle(PointerEventData data)
    {
        _buttonPush = false;
        PausePanel.SetActive(false);
        Time.timeScale = 1;

        //Effect재생
        AudioClip effectAudioClip = GameManager.Instance.LoadAudioClip(effectAudioClipPath);
        if (effectAudioClip != null)
            SoundManager.Instance.Play(effectAudioClip, Define.Sound.Effect);

        SoundManager.Instance.ResumeBGM();
    }

    void JumpButton(PointerEventData data)
    {
        if (player.stateMachine.currentState == player.fallingState
            || player.stateMachine.currentState == player.highState
            || player.stateMachine.currentState == player.downState
            || player.stateMachine.currentState == player.deathState)  
            return;

        if(player.isBonusStart == true)
        {
            if (player.gValue <= 0)
                return;
            BonusTimeButtonDown();
        }
        else
        {
            _buttonPush = true;

            if (player == null) return;

            if (player.IsGroundDetected())
            {
                isjumping = true;
                player.stateMachine.ChangeState(player.jumpState);
            }
        }

    }

    void JumpButtonUp(PointerEventData data)
    {
        if (player.stateMachine.currentState == player.fallingState
            || player.stateMachine.currentState == player.highState
            || player.stateMachine.currentState == player.downState
            || player.stateMachine.currentState == player.deathState)
            return;

        if (player.isBonusStart == true)
        {
            if (player.gValue <= 0)
                return;
            BonusTImeButtonUp();
        }
        else
        {
            _buttonPush = false;

        }

    }

    void DoubleJump(PointerEventData data)
    {
        if (player.stateMachine.currentState == player.fallingState
            || player.stateMachine.currentState == player.highState
            || player.stateMachine.currentState == player.downState
            || player.stateMachine.currentState == player.deathState)
            return;

        if (player.isBonusStart == false)
        {
            _buttonPush = true;

            if (player == null) return;
            if (!player.IsGroundDetected() && isjumping)
            {
                isjumping = false;
                player.stateMachine.ChangeState(player.doubleJumpState);  
            }
        }    
    }

    void DoubleJumpUP(PointerEventData data)
    {
        if (player.stateMachine.currentState == player.fallingState
            || player.stateMachine.currentState == player.highState
            || player.stateMachine.currentState == player.downState
            || player.stateMachine.currentState == player.deathState)
            return;

        if (player.isBonusStart == false)
        {
            _buttonPush = false;
        }
    }

    void SlideButton(PointerEventData data)
    {
        if (player.stateMachine.currentState == player.fallingState
            || player.stateMachine.currentState == player.highState
            || player.stateMachine.currentState == player.downState
            || player.stateMachine.currentState == player.deathState)
            return;

        if (player.isBonusStart == true)
        {
            if (player.gValue <= 0)
                return;

            BonusTimeButtonDown();
        }
        else // falling state가 끝나면 
        {
            if (player == null) return;

            if (player.IsGroundDetected())
            {
                player.stateMachine.ChangeState(player.slideState);  
            }

            _buttonPush = true;  

            Debug.Log("끝났어!!!!!!!!!!!");  

        }

    }

    void SlideButtonUp(PointerEventData data)
    {
        if (player.stateMachine.currentState == player.fallingState
            || player.stateMachine.currentState == player.highState
            || player.stateMachine.currentState == player.downState
            || player.stateMachine.currentState == player.deathState)  
            return;

        if (player.isBonusStart == true)
        {
            if (player.gValue <= 0)  
                return;  
            BonusTImeButtonUp();
        }
        else
        {
            _buttonPush = false;

            player.anim.SetBool("Idle", true);
            player.stateMachine.ChangeState(player.idleState);
        }

    }



    // code by 동호
    void BonusTimeButtonDown()
    {
        if (player == null)  // 플레이어 컴포넌트 없으면 리턴 
            return;

        if (player.isBonusStart == false && player.isBonusTime == false) // 보너스 타임이 끝났으면 리턴     
            return;    

        _buttonPush = true; // 버튼 푸시 플래스 활성화

        player.stateMachine.ChangeState(player.bonusUpState); // 보너스 상태에서의 점프 상태가 됨.
        StartCoroutine(JumpBonusTime());  // 점프 코루틴 실행 
    }
    void BonusTImeButtonUp()
    {
        _buttonPush = false; // 버튼 푸시 플래스 비활성화
        if (player == null) // 플레이어 컴포넌트 없으면 리턴 
            return;

        if (player.isBonusStart == false) // 보너스 타임이 끝났으면 리턴 
            return;

        player.stateMachine.ChangeState(player.bonusDownState); // 보너스 상태에서의 다운 상태가 됨. 
    }
    void OnButtonDown(PointerEventData data) // 보너스 타임에서의 플레이어 점프 버튼 클릭시 
    {
        Debug.Log("OnButtonDown");
        _buttonPush = true; // 버튼 푸시 플래스 활성화
        if (player == null)  // 플레이어 컴포넌트 없으면 리턴 
            return;

        if (bonusTimeFinish == true) // 보너스 타임이 끝났으면 리턴 
            return;
        player.stateMachine.ChangeState(player.bonusUpState); // 보너스 상태에서의 점프 상태가 됨.
        StartCoroutine(JumpBonusTime());  // 점프 코루틴 실행 
    }
    // code by 동호
    void OnButtonUp(PointerEventData data)
    {
        _buttonPush = false; // 버튼 푸시 플래스 비활성화
        if (player == null) // 플레이어 컴포넌트 없으면 리턴 
            return;

        if (bonusTimeFinish == true) // 보너스 타임이 끝났으면 리턴 
            return;
        player.stateMachine.ChangeState(player.bonusDownState); // 보너스 상태에서의 다운 상태가 됨.  


    }
    // code by 동호
    IEnumerator JumpBonusTime()
    {
        while (_buttonPush) // 버튼이 눌린 상태라면 
        {
            PlayerBonusJump();
            yield return new WaitForSeconds(0.1f); // 해당 시간 동안 쉰다.

        }
    }
    // code by 동호
    void PlayerBonusJump() // 점프 구현 
    {
        player.SetVelocity(0, player.bonusJumpPower);  // 플레이어의 리지드 바디의 속도를 설정해줌.  
    }
}