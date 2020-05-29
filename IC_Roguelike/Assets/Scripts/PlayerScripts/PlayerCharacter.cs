using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacter : Character
{
    private float superGauge;   // 스킬게이지\

    private int equipWeaponId;      // 착용중인 무기 id
    private Weapons equipWeapon;    // 착용중인 무기 정보값

    // #SetWeapon에서 동작 방식,조작법 변경
    // #뿐만아니라 공격력등을 여기서 배정한다
    public void SetWeapon(Weapons pWeapons)
    {
    }
}
