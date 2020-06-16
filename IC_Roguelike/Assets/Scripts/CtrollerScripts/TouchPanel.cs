using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TouchPanel : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public enum CharacterState
    {
        IDLE,
        UP,
        DOWN,
        LEFT,
        RIGHT,
    }

    // 진행방향 체크를 위한 변수
    public CharacterState characterState = CharacterState.IDLE;

    private PlayerCharacter Player;     // 플레이어
    private Vector2 firstTouchPosition; // 터치위치1
    private Vector2 finalTouchPosition; // 터치위치2
    private float swipeResist = 0.5f;   // 스와이프 제한 거리
    private float swipeAngle = 0;        // 스와이프 각도

    private Animator anim;                  // Animator를 불러오기 위한 변수
    private AnimationController animCtrl;   // AnimationController를 불러오기 위한 변수

    [SerializeField] private float delayTime = 0.7f;     // 얼마나 누르고 있을건지
    private float chargeTime = 0.0f;    // 홀드 지속시간
    private bool holdTouch = false;     // 홀딩하고 있는지 확인

    void Update()
    {
        CheckHoldTime();
    }

    // 터치시작
    public void OnPointerDown(PointerEventData data)
    {
        holdTouch = true;
        firstTouchPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

    // 터치종료
    public void OnPointerUp(PointerEventData data)
    {
        holdTouch = false;
        finalTouchPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        CalculateAngle();
    }

    // 이동 방향구하기
    private void CalculateAngle()
    {
        // 스와이프 거리를 절대값으로 변환해 거리제한
        if (Mathf.Abs(finalTouchPosition.y - firstTouchPosition.y) > swipeResist || Mathf.Abs(finalTouchPosition.x - firstTouchPosition.x) > swipeResist)
        {
            Debug.Log(finalTouchPosition.x - firstTouchPosition.x);
            swipeAngle = Mathf.Atan2(finalTouchPosition.y - firstTouchPosition.y, finalTouchPosition.x - firstTouchPosition.x) * Mathf.Rad2Deg;
        }
        //Debug.Log(swipeAngle);

        if(swipeAngle > -45 && swipeAngle <= 45)
        {
            // Right
            //Debug.Log("Right");
            characterState = CharacterState.RIGHT;
        }
        else if (swipeAngle > 45 && swipeAngle <= 135)
        {
            // Up
            //Debug.Log("Up");
            characterState = CharacterState.UP;
        }
        else if (swipeAngle > 135 || swipeAngle <= -135)
        {
            // Left
            characterState = CharacterState.LEFT;
        }
        else if (swipeAngle < -45 && swipeAngle >= -135)
        {
            // Down
            //Debug.Log("Down");
            characterState = CharacterState.DOWN;

        }
        if (chargeTime >= delayTime)
        {
            characterState = CharacterState.IDLE;
        }
    }

    // 터치 스와이프 이동
    public void SwipeMove(Transform pTrans, float pSpd)
    {
        if(characterState == CharacterState.UP)
        {
            pTrans.position += Vector3.up * pSpd * Time.deltaTime;
        }
        else if(characterState == CharacterState.DOWN)
        {
            pTrans.position += Vector3.down * pSpd * Time.deltaTime;
        }
        else if (characterState == CharacterState.LEFT)
        {
            pTrans.position += Vector3.left * pSpd * Time.deltaTime;
        }
        else if (characterState == CharacterState.RIGHT)
        {
            pTrans.position += Vector3.right * pSpd * Time.deltaTime;
        }
        if(characterState == CharacterState.IDLE)
        {
            pTrans.position += Vector3.zero * pSpd * Time.deltaTime;
        }
    }

    // 터치 홀딩타임 체크
    private void CheckHoldTime()
    {
        if(holdTouch)
        {
            chargeTime += Time.deltaTime;
        }
        else
        {
            chargeTime = 0;
        }

        if (chargeTime >= delayTime)
            characterState = CharacterState.IDLE;
    }
}
