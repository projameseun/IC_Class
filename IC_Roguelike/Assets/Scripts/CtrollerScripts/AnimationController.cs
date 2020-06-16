using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    TouchPanel touchPanel;

    // 플레이어 애니메이션
    public void PlayerAnimCtrl(Animator pAnim, Vector2 pLastMove, bool pIsMove)
    {
        pIsMove = false; // 방향키를 누르지 않으면 false로 변경

        if (Input.GetAxisRaw("Horizontal") > 0 || Input.GetAxisRaw("Horizontal") < 0)
        {
            pIsMove = true;  // 플레이어가 움직이고 있다.
        }

        if (Input.GetAxisRaw("Vertical") > 0 || Input.GetAxisRaw("Vertical") < 0)
        {
            pIsMove = true;  // 플레이어가 움직이고 있다.
        }

        // 애니메이션 MoveX, MoveY
        pAnim.SetFloat("MoveX", Input.GetAxisRaw("Horizontal"));
        pAnim.SetFloat("MoveY", Input.GetAxisRaw("Vertical"));
        pAnim.SetBool("IsMove", pIsMove);   // 애니메이션 IsMove를 isMove와 같도록 설정
        pAnim.SetFloat("LastMoveX", pLastMove.x); // LastMoveX를 lastMove의 X값과 같게 설정
        pAnim.SetFloat("LastMoveY", pLastMove.y); // LastMoveY를 lastMove의 y값과 같게 설정
    }

    // 플레이어 스와이프 애니메이션
    public void PlayerSwipeAimCtrl(Animator pAnim, Vector2 pLastMove, bool pIsMove, TouchPanel touch)
    {
        pIsMove = false;
        if(touch.characterState == TouchPanel.CharacterState.IDLE)
        {
            pIsMove = false;
        }
        else if(touch.characterState == TouchPanel.CharacterState.UP)
        {
            // 상
            pIsMove = true;
            pAnim.SetFloat("MoveY", 1);
            pAnim.SetFloat("LastMoveY", 1);
            pAnim.SetFloat("MoveX", 0);
            pAnim.SetFloat("LastMoveX", 0);

        }
        else if (touch.characterState == TouchPanel.CharacterState.DOWN)
        {
            // 하
            pIsMove = true;
            pAnim.SetFloat("MoveY", -1);
            pAnim.SetFloat("LastMoveY",-1);
        }
        else if(touch.characterState == TouchPanel.CharacterState.LEFT)
        {
            // 좌
            pIsMove = true;
            pAnim.SetFloat("MoveX", -1);
            pAnim.SetFloat("LastMoveX", -1);
            pAnim.SetFloat("MoveY", 0);
            pAnim.SetFloat("LastMoveY", 0);
        }
        else if(touch.characterState == TouchPanel.CharacterState.RIGHT)
        {
            // 우
            pIsMove = true;
            pAnim.SetFloat("MoveX", 1);
            pAnim.SetFloat("LastMoveX", 1);
            pAnim.SetFloat("MoveY", 0);
            pAnim.SetFloat("LastMoveY", 0);
        }
        pAnim.SetBool("IsMove", pIsMove);   // 애니메이션 IsMove를 isMove와 같도록 설정
    }
}
