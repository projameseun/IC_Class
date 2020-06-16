using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageManager : MonoBehaviour
{
    public List<StageInfo> StageList = new List<StageInfo>();

    private void Start()
    {
      for(int i=0; i<10; i++)
        {
            StageList.Add(new StageInfo()
            {
                Stageid = i + 1,       
                StageName = "스테이지" + (i + 1).ToString(),
                  
            });
           

        }

    }
    public void SetStageList(List<StageInfo> a_StageList)
    {
        Debug.Log("SetStageLIst");
        StageList = a_StageList;
    }
}
