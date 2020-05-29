using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// #플레이어경우 무기 att속성
// #몬스터나 npc경우 직접 불러온다.
// #이는 하위 클래스에서 해줄것

public abstract class Character : ICObject
{
    protected string name;  // 캐릭터 명(Prefabs 이름)
    protected float radius; // 충돌 반경
    protected float hp;     // 오브젝트 hp <= 0 일시 Destroy
    protected float att;    // 공격력
    protected float spd;    // 이동속도

    private bool isCanControl; // 컨트롤 가능한가?
    private bool isCanKnockback; // 넉백이 되는가?
}
