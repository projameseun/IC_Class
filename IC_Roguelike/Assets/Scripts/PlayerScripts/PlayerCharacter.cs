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
    private TouchPanelController touchPanelCtrl;

    private Vector2 lastMove;       // 마지막 움직임이 어느 방향이었는지 확인하기 위한 변수
    private bool isMove;    // 플레이어가 움직이는지 확인

    private float h, v;
    Vector3 moveNextStep;   // 이동속도 계산을 위한 변수
    Vector3 moveHStep;
    Vector3 moveVStep;

    [HideInInspector] public float atkDelay;
    public float atkCoolTime = 1f;               // 공격 쿨타임

    void Start()
    {
        anim = GetComponent<Animator>();    // 애니메이터 불러오기
        animCtrl = GetComponent<AnimationController>(); // 애니메이션컨트롤 불러오기
        touchPanelCtrl = FindObjectOfType<TouchPanelController>();
        // 이동속도
        this.spd = 2f;
    }

    void Update()
    {
        // 플레이어 이동
        Move();
        // 플레이어 이동 애니메이션
        //animCtrl.PlayerAnimCtrl(anim, lastMove, isMove);

        //touchPanelCtrl.SetAnimCtrl(anim, lastMove, isMove);
    }

    void Move()
    {
        h = Input.GetAxisRaw("Horizontal");
        v = Input.GetAxisRaw("Vertical");

        if (0.0f != h || 0.0f != v)
        {
            moveHStep = Vector3.right * h;
            moveVStep = Vector3.up * v;
            

            moveNextStep = moveHStep + moveVStep;
            moveNextStep = moveNextStep.normalized * spd * Time.deltaTime;

            transform.position = transform.position + moveNextStep;
            if (Input.GetAxisRaw("Horizontal") > 0 || Input.GetAxisRaw("Horizontal") < 0)
            {
                lastMove = moveHStep;
            }
            if (Input.GetAxisRaw("Vertical") > 0 || Input.GetAxisRaw("Vertical") < 0)
            {
                lastMove = moveVStep;
            }
        }
    }



    // #SetWeapon에서 동작 방식,조작법 변경
    // #뿐만아니라 공격력등을 여기서 배정한다
    public void SetWeapon(Weapons pWeapons)
    {
    }

    
}
