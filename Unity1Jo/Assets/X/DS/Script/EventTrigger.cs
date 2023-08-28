using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventTrigger : MonoBehaviour
{
    GameObject player;
    Vector2 click;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void JumpPadDown()
    {
        click = Input.mousePosition;

        Player splayer = player.GetComponent<Player>();
        splayer.stateMachine.ChangeState(splayer.jumpState);
    }

    void JumpPadUp()
    {
        Player splayer = player.GetComponent<Player>();
        splayer.stateMachine.ChangeState(splayer.idleState);
    }

    void SlidePadDown()
    {
        click = Input.mousePosition;
        Player splayer = player.GetComponent<Player>();
        splayer.stateMachine.ChangeState(splayer.slideState);
    }

    void SlidePadUp()
    {
        Player splayer = player.GetComponent<Player>();
        splayer.stateMachine.ChangeState(splayer.idleState);
    }
}
