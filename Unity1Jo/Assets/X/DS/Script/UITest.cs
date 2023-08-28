using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UITest : UI_Base
{
    [SerializeField] Button Jump;
    [SerializeField] Button Slide;
    [SerializeField] GameObject PausePanel;
    [SerializeField] Button Pause;
    [SerializeField] Button KeepGame;
    bool _buttonPush; // button push flag
   
    Player player;

    public bool bonusTimeFinish = false; // 보너스 시간 끝났을 때 체크 (이거는 UIManager에서 보너스타임이 끝났는 지 알아야 할 플래그 변수 )
    private void Start()
    {
        //BonusJump.gameObject.AddUIEvent(ButtonClicked, type : Define.UIEvent.PointerDown);  
        Jump.gameObject.AddUIEvent(JumpButton, type: Define.UIEvent.PointerDown); // 버튼 다운 했을 떄 이벤트 등록 (타입의 기본값 : Define.UIEvent.Click)
        Jump.gameObject.AddUIEvent(JumpButtonUp, type: Define.UIEvent.PointerUp); // 버튼 업 했을 떄 이벤트 등록 (타입의 기본값 : Define.UIEvent.Click)
        Jump.gameObject.AddUIEvent(DoubleJump, type: Define.UIEvent.PointerDown);
        Jump.gameObject.AddUIEvent(DoubleJumpUP, type: Define.UIEvent.PointerUp);
        Pause.gameObject.AddUIEvent(PauseGame, type: Define.UIEvent.PointerDown);
        KeepGame.gameObject.AddUIEvent(PauseCancle, type: Define.UIEvent.PointerDown);

        Slide.gameObject.AddUIEvent(SlideButton, type: Define.UIEvent.PointerDown);
        Slide.gameObject.AddUIEvent(SlideButtonUp, type: Define.UIEvent.PointerUp);

        GameObject playerObj = PlayerManager.Instance.GetPlayer(); // PlayManager라는 싱글톤 클래스에서 플레이어 게임 오브젝트 얻어옴.
        if (playerObj == null) // 플레이어 오브젝트가 없으면 리턴 
            return;
        player = playerObj.GetComponent<Player>(); // 플레이어 컴포넌트 가져옴 
    }

    void PauseGame(PointerEventData data)
    {
        _buttonPush = true;
        PausePanel.SetActive(true);
        Time.timeScale = 0;
    }

    void PauseCancle(PointerEventData data)
    {
        _buttonPush = false;
        PausePanel.SetActive(false);
        Time.timeScale = 1;
    }

    void JumpButton(PointerEventData data)
    {
        _buttonPush = true;
       
        
        if(player == null) return;
        if (player.IsGroundDetected())
        {
            player.stateMachine.ChangeState(player.jumpState);
        }
    }

    void JumpButtonUp(PointerEventData data)
    {
        _buttonPush = false;
       
    }

    void DoubleJump(PointerEventData data)
    {
        _buttonPush = true;

        if(player == null) return;
        if (!player.IsGroundDetected())
            player.stateMachine.ChangeState(player.doubleJumpState);
        
    }

    void DoubleJumpUP(PointerEventData data)
    {
        _buttonPush = false;
    }

    void SlideButton(PointerEventData data)
    {
        _buttonPush = true;
        if(player == null) return;
        if(player.IsGroundDetected())
            player.stateMachine.ChangeState(player.slideState);
    }

    void SlideButtonUp(PointerEventData data)
    {
        _buttonPush = false;
        player.stateMachine.ChangeState(player.idleState);
    }



    // code by 동호
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