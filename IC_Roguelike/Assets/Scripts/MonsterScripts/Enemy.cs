using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Character
{
    protected int id;   // 오브젝트 ID값(정보를 위함)
    protected int rank; // 몬스터 등급
    protected List<MonsterAction> actionList;   // 작동 리스트(행동 리스트)
    public float dropEXP;   // 스테이지 클리어를 위한 경험치 드랍양


    [HideInInspector] public bool isFind = false;
    [HideInInspector] public bool isLost = false;

    private Animator animator;

    [Header("View Config")]
    [SerializeField] private bool bDebugMode = false;

    private float sight = 0f; // 시야각
    private float viewDistance = 1000f; // 시야 거리

    private float viewRotate = 0f; // 시야각의 회전값
    private float rotateSpeed = 1f; // 시야각의 회전속도

    [SerializeField] private LayerMask viewTargetMask;       // 인식 가능한 타켓의 마스크
    [SerializeField] private LayerMask viewObstacleMask;     // 인식 방해물의 마스크 

    [HideInInspector] public float atkDelay;
    public float atkCoolTime = 3;               // 공격 쿨타임

    [HideInInspector] public Transform player;  // 추적대상위치
    private float viewHalfAngle = 0f; // 시야각의 절반 값
    private bool isTrace = false;    // 추적중인가?

    private List<Collider2D> hitedTargetContainer = new List<Collider2D>(); // 인식한 물체들을 보관할 컨테이너

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        this.spd = 0.7f;
    }

    // Update is called once per frame
    void Update()
    {
        FindViewTargets();

        if (atkDelay >= 0)
            atkDelay -= Time.deltaTime;

    }

    // 범위내 플레이어 찾기
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
                    isFind = false;

                    if (bDebugMode)
                        Debug.DrawLine(originPos, rayHitedObstacle.point, Color.yellow);
                }
                else if (rayHitedPlayer)
                {
                    hitedTargetContainer.Add(hitedTarget);

                    isTrace = true;
                    isFind = true;

                    if (bDebugMode)
                        Debug.DrawLine(originPos, targetPos, Color.red);
                }
            }

            if (Vector3.Distance(player.position, transform.position) < 0.7f)
            {
                LookPlayer();

            }
        }

        if (hitedTargetContainer.Count > 0)
            return hitedTargetContainer.ToArray();
        else
            return null;


    }

    // 애니메이션 방향 조정
    public void DirectionEnemy(float target, float baseobj)
    {
        if (target < baseobj)
            animator.SetFloat("Direction", -1);
        else
            animator.SetFloat("Direction", 1);
    }

    // 플레이어 따라가기
    public void TracePlayer()
    {
        if (isTrace)
        {
            transform.position = Vector3.MoveTowards(transform.position, player.transform.position, this.spd * Time.deltaTime);
            LookPlayer();
        }
        else
            LostPlayer();
    }

    // 플레이어 놓침
    private void LostPlayer()
    {
        float targetDistance = Vector3.Distance(player.position, transform.position);

        if (targetDistance > viewDistance)
        {
            isTrace = false;
            isFind = false;
        }
    }

    // -180~180의 값을 Up Vector 기준 Local Direction으로 변환시켜줌.
    private Vector2 AngleToDirZ(float angleInDegree)
    {
        float radian = (angleInDegree - transform.eulerAngles.z) * Mathf.Deg2Rad;
        return new Vector3(Mathf.Sin(radian), Mathf.Cos(radian));
    }

    // 플레이어 바라보기
    private void LookPlayer()
    {
        if (isTrace)
        {
            float angular = -(GetAngle(player.position, transform.position) - 180);
            viewRotate = Mathf.Lerp(viewRotate, angular, rotateSpeed);
            //Debug.Log(angular);
        }
    }

    // 두 Vector 사이의 -180~180 각도 구하기
    private float GetAngle(Vector3 vStart, Vector3 vEnd)
    {
        return Quaternion.FromToRotation(Vector3.up, vEnd - vStart).eulerAngles.z;
    }

}
