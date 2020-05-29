using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : Character
{
    protected int id;   // 오브젝트 ID값(정보를 위함)
    protected int rank; // 몬스터 등급
    protected List<MonsterAction> actionList;   // 작동 리스트(행동 리스트)

    public float sight;     // 시야각
    public float dropEXP;   // 스테이지 클리어를 위한 경험치 드랍양

    public char weakPoint;
}
