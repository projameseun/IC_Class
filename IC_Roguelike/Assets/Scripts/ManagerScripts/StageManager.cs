using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageManager : MonoBehaviour
{
    public List<StageInfo> StageList = new List<StageInfo>();

    public void SetStageList(List<StageInfo> a_StageList)
    {
        Debug.Log("SetStageLIst");
        StageList = a_StageList;
    }
}
