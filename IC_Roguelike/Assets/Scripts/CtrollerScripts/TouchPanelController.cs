using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TouchPanelController : MonoBehaviour, IDragHandler, IPointerDownHandler, IPointerUpHandler
{
    [Range(0,1.0f)]
    [SerializeField ]private float limitMovement = 0.5f;

    public Animator animator;
    public GameObject playerObject;
    Vector2 touchPos;
    Vector2 diffPos;
    [HideInInspector] public bool isClick = false;

    public void OnDrag(PointerEventData eventData)
    {
        Vector2 worldPoint = Input.mousePosition;
        worldPoint = Camera.main.ScreenToWorldPoint(worldPoint);

        diffPos = (worldPoint - touchPos) * limitMovement;

        touchPos = Input.mousePosition;
        touchPos = Camera.main.ScreenToWorldPoint(touchPos);

        playerObject.transform.position = new Vector2(playerObject.transform.position.x + diffPos.x,
                                                        playerObject.transform.position.y + diffPos.y);
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        touchPos = Input.mousePosition;
        touchPos = Camera.main.ScreenToWorldPoint(touchPos);

        isClick = true;
        //Debug.Log("touchPos : " + touchPos);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        diffPos = Vector2.zero;

        isClick = false;
    }

    public void DirectionPlayer()
    {
        if(diffPos.x < 0)
        {
            animator.SetFloat("DirectionX", -1);
        }
        else if(diffPos.x > 0)
        {
            animator.SetFloat("DirectionX", 1);
        }

        if (diffPos.y < 0)
        {
            animator.SetFloat("DirectionY", -1);
        }
        else if (diffPos.y > 0)
        {
            animator.SetFloat("DirectionY", 1);
        }
    }

    public void SetAnimCtrl(Animator pAnim, Vector2 pLastMove, bool pIsMove)
    {
        pIsMove = false;

        if(diffPos.x > 0 || diffPos.x < 0)
        {
            pIsMove = true;
        }

        if(diffPos.y > 0 || diffPos.y < 0)
        {
            pIsMove = true;
        }

        pAnim.SetFloat("MoveX", diffPos.x);
        pAnim.SetFloat("MoveY", diffPos.y);
        pAnim.SetBool("IsMove", pIsMove);   // 애니메이션 IsMove를 isMove와 같도록 설정
        pAnim.SetFloat("LastMoveX", pLastMove.x); // LastMoveX를 lastMove의 X값과 같게 설정
        pAnim.SetFloat("LastMoveY", pLastMove.y); // LastMoveY를 lastMove의 y값과 같게 설정
    }
}
