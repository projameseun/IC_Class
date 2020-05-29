using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacter : Character
{
    private float superGauge;   // 스킬게이지

    private int equipWeaponId;      // 착용중인 무기 id
    private Weapons equipWeapon;    // 착용중인 무기 정보값

    private Animator anim;                  // Animator를 불러오기 위한 변수
    private AnimationController animCtrl;   // AnimationController를 불러오기 위한 변수

    private Vector2 lastMove;       // 마지막 움직임이 어느 방향이었는지 확인하기 위한 변수
    private bool isMove;    // 플레이어가 움직이는지 확인

    void Start()
    {
        anim = GetComponent<Animator>();    // 애니메이터 불러오기
        animCtrl = GetComponent<AnimationController>(); // 애니메이션컨트롤 불러오기

        // 이동속도
        this.spd = 2;
    }

    void Update()
    {
        // 좌우 움직이기
        if (Input.GetAxisRaw("Horizontal") > 0 || Input.GetAxisRaw("Horizontal") < 0)
        {
            transform.Translate(new Vector3(Input.GetAxisRaw("Horizontal") * this.spd * Time.deltaTime, 0f, 0f));
            lastMove = new Vector2(Input.GetAxisRaw("Horizontal"), 0f); // lastMove의 X 값을 Horizontal로 설정
        }
        // 상하 움직이기
        if (Input.GetAxisRaw("Vertical") > 0 || Input.GetAxisRaw("Vertical") < 0)
        {
            transform.Translate(new Vector3(0, Input.GetAxisRaw("Vertical") * this.spd * Time.deltaTime, 0f));
            lastMove = new Vector2(0f, Input.GetAxisRaw("Vertical")); // lastMove의 Y 값을 Vertical 설정
        }

        // 플레이어 이동 애니메이션
        animCtrl.PlayerAnimCtrl(anim, lastMove, isMove);
    }

    // #SetWeapon에서 동작 방식,조작법 변경
    // #뿐만아니라 공격력등을 여기서 배정한다
    public void SetWeapon(Weapons pWeapons)
    {
    }

    
}
