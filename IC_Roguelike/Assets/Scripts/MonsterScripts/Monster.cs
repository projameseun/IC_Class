﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : Character
{
    protected int id;   // 오브젝트 ID값(정보를 위함)
    protected int rank; // 몬스터 등급
    protected List<MonsterAction> actionList;   // 작동 리스트(행동 리스트)
    public float dropEXP;   // 스테이지 클리어를 위한 경험치 드랍양
    

    public char weakPoint;

    [Header("View Config")]
    [SerializeField] private bool bDebugMode = false;
    
    private float sight = 0f; // 시야각
    private float viewDistance = 100f; // 시야 거리
    
    private float viewRotate = 0f; // 시야각의 회전값
    private float rotateSpeed = 1f; // 시야각의 회전속도

    [SerializeField] private LayerMask viewTargetMask;       // 인식 가능한 타켓의 마스크
    [SerializeField] private LayerMask viewObstacleMask;     // 인식 방해물의 마스크 
    

    private List<Collider2D> hitedTargetContainer = new List<Collider2D>(); // 인식한 물체들을 보관할 컨테이너

    private float viewHalfAngle = 0f; // 시야각의 절반 값
    private Transform traceTarget;  // 추적대상위치
    private Animator anim;          // 애니메이션
    private bool isTrace = false;    // 추적중인가?


    void Awake()
    {
        viewHalfAngle = sight * 0.5f;
    }

    void Start()
    {
        anim = GetComponent<Animator>();
        traceTarget = FindObjectOfType<PlayerCharacter>().transform;
        this.spd = 0.7f;
    }

    void Update()
    {
        FindViewTargets();
        TracePlayer();
    }

    // 씬 테스트용 기즈모 그리기
    //private void OnDrawGizmosSelected()
    //{
    //    if (bDebugMode)
    //    {
    //        viewHalfAngle = sight * 0.5f;

    //        Vector3 originPos = transform.position;

    //        Gizmos.DrawWireSphere(originPos, viewDistance);

    //        Vector3 horizontalRightDir = AngleToDirZ(viewHalfAngle + viewRotate);
    //        Vector3 horizontalLeftDir = AngleToDirZ(-viewHalfAngle + viewRotate);
    //        Vector3 lookDir = AngleToDirZ(viewRotate);

    //        Debug.DrawRay(originPos, horizontalLeftDir * viewDistance, Color.cyan);
    //        Debug.DrawRay(originPos, lookDir * viewDistance, Color.green);
    //        Debug.DrawRay(originPos, horizontalRightDir * viewDistance, Color.cyan);

    //        //FindViewTargets();
    //    }
    //}

    // 플레이어 찾기

    public Collider2D[] FindViewTargets()
    {
        hitedTargetContainer.Clear();

        Vector2 originPos = transform.position;
        Collider2D[] hitedTargets = Physics2D.OverlapCircleAll(originPos, viewDistance, viewTargetMask);

        foreach (Collider2D hitedTarget in hitedTargets)
        {
            Vector2 targetPos = hitedTarget.transform.position;
            Vector2 dir = (targetPos - originPos).normalized;
            Vector2 lookDir = AngleToDirZ(viewRotate);

            // float angle = Vector3.Angle(lookDir, dir)
            // 아래 두 줄은 위의 코드와 동일하게 동작함. 내부 구현도 동일
            float dot = Vector2.Dot(lookDir, dir);
            float angle = Mathf.Acos(dot) * Mathf.Rad2Deg;

            //if (angle <= viewHalfAngle)
            {
                RaycastHit2D rayHitedObstacle = Physics2D.Raycast(originPos, dir, viewDistance, viewObstacleMask);
                RaycastHit2D rayHitedPlayer = Physics2D.Raycast(originPos, dir, viewDistance, viewTargetMask);
                if (rayHitedObstacle)
                {
                    //LostPlayer();
                    isTrace = false;

                    if (bDebugMode)
                        Debug.DrawLine(originPos, rayHitedObstacle.point, Color.yellow);
                }
                else if (rayHitedPlayer) 
                {
                    hitedTargetContainer.Add(hitedTarget);

                    isTrace = true;

                    if (bDebugMode)
                        Debug.DrawLine(originPos, targetPos, Color.red);
                }
                else
                {
                    isTrace = false;
                    //LostPlayer();
                    //Debug.Log(isTrace);
                }
            }

            if (Vector3.Distance(traceTarget.position, transform.position) < 0.7f)
            {
                LookPlayer();
                
            }
        }

        if (hitedTargetContainer.Count > 0)
            return hitedTargetContainer.ToArray();
        else
            return null;

        
    }

    // -180~180의 값을 Up Vector 기준 Local Direction으로 변환시켜줌.
    private Vector2 AngleToDirZ(float angleInDegree)
    {
        float radian = (angleInDegree - transform.eulerAngles.z) * Mathf.Deg2Rad;
        return new Vector3(Mathf.Sin(radian), Mathf.Cos(radian));
    }

    // 두 Vector 사이의 -180~180 각도 구하기
    private float GetAngle(Vector3 vStart, Vector3 vEnd)
    {
        return Quaternion.FromToRotation(Vector3.up, vEnd - vStart).eulerAngles.z;
    }

    // 플레이어 따라가기
    private void TracePlayer()
    {
        if (isTrace)
        {
            transform.position = Vector3.MoveTowards(transform.position, traceTarget.transform.position, spd * Time.deltaTime);
            LookPlayer();

            anim.SetBool("IsMove", true);
            anim.SetFloat("MoveX", (traceTarget.position.x - transform.position.x));
            anim.SetFloat("MoveY", (traceTarget.position.y - transform.position.y));
            anim.SetFloat("LastMoveX", (traceTarget.position.x - transform.position.x)); // LastMoveX를 lastMove의 X값과 같게 설정
            anim.SetFloat("LastMoveY", (traceTarget.position.y - transform.position.y)); // LastMoveY를 lastMove의 y값과 같게 설정
        }
        else
            LostPlayer();
    }

    // 플레이어 놓침
    private void LostPlayer()
    {
        float targetDistance = Vector3.Distance(traceTarget.position, transform.position);
        anim.SetBool("IsMove", false);
        if (targetDistance > viewDistance)
        {
            isTrace = false;
        }
    }

    // 플레이어 바라보기
    private void LookPlayer()
    {
        if (isTrace)
        {
            float angular = -(GetAngle(traceTarget.position, transform.position) - 180);
            viewRotate = Mathf.Lerp(viewRotate, angular, rotateSpeed);
            //Debug.Log(angular);
        }
    }
}
