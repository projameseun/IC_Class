using System.Collections;
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
    [Range(0f, 360f)]
    [SerializeField] private float sight = 0f; // 시야각
    [SerializeField] private float viewDistance = 1f; // 시야 거리
    [Range(-180f, 180f)]
    [SerializeField] private float viewRotate = 0f; // 시야각의 회전값

    [SerializeField] private LayerMask viewTargetMask;       // 인식 가능한 타켓의 마스크
    [SerializeField] private LayerMask viewObstacleMask;     // 인식 방해물의 마스크 

    private List<Collider2D> hitedTargetContainer = new List<Collider2D>(); // 인식한 물체들을 보관할 컨테이너

    private float viewHalfAngle = 0f; // 시야각의 절반 값

    void Awake()
    {
        viewHalfAngle = sight * 0.5f;
    }

    void Start()
    {
        this.spd = 1.5f;
    }

    private void OnDrawGizmosSelected()
    {
        if (bDebugMode)
        {
            viewHalfAngle = sight * 0.5f;

            Vector3 originPos = transform.position;

            Gizmos.DrawWireSphere(originPos, viewDistance);

            Vector3 horizontalRightDir = AngleToDirZ(viewHalfAngle + viewRotate);
            Vector3 horizontalLeftDir = AngleToDirZ(-viewHalfAngle + viewRotate);
            Vector3 lookDir = AngleToDirZ(viewRotate);

            Debug.DrawRay(originPos, horizontalLeftDir * viewDistance, Color.cyan);
            Debug.DrawRay(originPos, lookDir * viewDistance, Color.green);
            Debug.DrawRay(originPos, horizontalRightDir * viewDistance, Color.cyan);

            FindViewTargets();
        }
    }

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

            if (angle <= viewHalfAngle)
            {
                RaycastHit2D rayHitedTarget = Physics2D.Raycast(originPos, dir, viewDistance, viewObstacleMask);
                if (rayHitedTarget)
                {
                    if (bDebugMode)
                        Debug.DrawLine(originPos, rayHitedTarget.point, Color.yellow);
                }
                else
                {
                    hitedTargetContainer.Add(hitedTarget);
                    

                    if (bDebugMode)
                        Debug.DrawLine(originPos, targetPos, Color.red);
                }
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
}
