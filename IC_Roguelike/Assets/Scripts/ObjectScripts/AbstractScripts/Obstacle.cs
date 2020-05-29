using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Obstacle : ICObject
{
    // 캐릭터와 상호작용시 해야할 함수
    public abstract void Act(Character T);
    
}
