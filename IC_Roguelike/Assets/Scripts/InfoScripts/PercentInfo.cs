using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Diagnostics;

[System.Serializable]
public class PercentInfo //: MonoBehaviour 
{
    //MonoBehaveiour 상속을 받으면 게임오브젝트가 생긴다.
    //그러기때문에 게임오브젝트가 아닌 그값만 가지고싶으면
    //Mono를 상속하지않는다 
    public int ID;
    public float Percent;
    public bool is_Complete = false;

   
    static public int RandomSelcet(List<PercentInfo> a_RandomList)
    {
        int a_WorldListCount = a_RandomList.Count;

        int Chapteidx = GameManager.instance.WdManager.SelectedWorldID - 1;
       // Debug.Log(Chapteidx);
        
        float PercentBool = 0;
        for (int i = 0; i < a_RandomList.Count; i++)
        {
          if(GameManager.instance.WdManager.WorldList[Chapteidx].World_ChapterList[i].Chapterid != i)
            PercentBool += a_RandomList[i].Percent;
      
        }// for(int i=0; i<World_RandomChapterList.Count; i++)

      //

        int ResultSel = 0;
        //float Calc = 0.0f;
        float CompareResult = 0.0f;

        for (int i = 0; i < a_WorldListCount; i++)
        {
            if (GameManager.instance.WdManager.WorldList[Chapteidx].World_ChapterList[i].Chapterid != i)
            {
                float rand = Random.Range(0.0f,PercentBool);
                //Debug.Log("rand" + rand);
                CompareResult += a_RandomList[i].Percent;

                if (rand <= CompareResult)
                {
                    //이때넣어준다
                    ResultSel = i + 1;
                    //Debug.Log("Result:" + ResultSel);
                 
                    return ResultSel;
                }//if (rand <=CompareResult )
            }
        }// for (int i = 0; i < a_WorldListCount; i++)
  
        return ResultSel;

    }//public int  RandomSelcet()
}
