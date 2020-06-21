using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class StageInfo
{
    //StageName을 통해서 Resource파일에 있는 프리팹이랑 나중에 연결할예정
    public int Stageid;
    public int expAmount;
    public int currDiffculty;
    public string StageName;

  
    public StageInfo() { }
    public StageInfo(int stageid, int expAmount, int currDiffculty, string stageName)
    {
        Stageid = stageid;
        this.expAmount = expAmount;
        this.currDiffculty = currDiffculty;
        StageName = stageName;
    }
}
