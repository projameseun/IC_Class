using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Data.Common;

[System.Serializable]
public class PercentInfo //: MonoBehaviour 
{
    //MonoBehaveiour 상속을 받으면 게임오브젝트가 생긴다.
    //그러기때문에 게임오브젝트가 아닌 그값만 가지고싶으면
    //Mono를 상속하지않는다 
    public int ID;
    public float Percent;
    private bool is_Complete = false;
    
    static public int RandomSelcet(List<PercentInfo> a_RandomList)
    {
        int a_WorldListCount = a_RandomList.Count;
        //Debug.Log(a_WorldListCount);

        //float PercentBool = 0;
        //for (int i = 0; i < a_RandomList.Count; i++)
        //{
        //    PercentBool += a_RandomList[i].Percent;
        //}// for(int i=0; i<World_RandomChapterList.Count; i++)

        

        //랜덤챕터리스트가 100퍼센트일때 만 들어옴

        int ResultSel = 0;
        //float Calc = 0.0f;
        float CompareResult = 0.0f;

        float PercentBool = 0.0f;

        for(int i=0; i<GameManager.instance.WdManager.NowPlayWorld.World_ChapterList.Count; i++)
        {
            //Debug.Log(GameManager.instance.WdManager.NowPlayWorld.World_ChapterList[i].Chapterid);
        }

        if (GameManager.instance.WdManager.NowPlayWorld.isChapter == false)
        {
            //Debug.Log("설마여기");
            for (int i = 0; i < a_RandomList.Count; i++)
            {
                PercentBool += a_RandomList[i].Percent;
            }
        }
        else if(GameManager.instance.WdManager.NowPlayWorld.isChapter == true)
        {
           
            for (int i = 0; i < GameManager.instance.WdManager.NowPlayWorld.World_ChapterList.Count; i++)
            {
                for (int j = 0; j < a_RandomList.Count; j++)
                {
                    if (GameManager.instance.WdManager.NowPlayWorld.World_ChapterList[i].Chapterid == a_RandomList[j].ID)
                    {
                        a_RandomList.RemoveAt(j);

                    }
                }
            }

            Debug.Log(a_RandomList.Count + "ListCount");
            int a_Count = a_RandomList.Count;
            Debug.Log(a_Count);
          
            for (int i = 0; i < a_Count; i++)
            {   
               
                PercentBool += a_RandomList[i].Percent;
            }

           // Debug.Log(PercentBool + "확인");
        }
        
       
        for (int i = 0; i < a_WorldListCount; i++)
        {
          

                float rand = Random.Range(0.0f, PercentBool);
            //Debug.Log("rand" + rand);
            CompareResult += a_RandomList[i].Percent;

            if (rand <= CompareResult)
            {

                //이때넣어준다
                ResultSel = a_RandomList[i].ID;
                //Debug.Log("Result:" + ResultSel);

                return ResultSel;
               
            }//if (rand <=CompareResult )

           

        }// for (int i = 0; i < a_WorldListCount; i++)
       
        return ResultSel;

    }//public int  RandomSelcet()

    static public int StageRandomSelect(List<PercentInfo> a_RandomList)
    {
        int a_WorldListCount = a_RandomList.Count;
        //Debug.Log(a_WorldListCount);

        //float PercentBool = 0;
        //for (int i = 0; i < a_RandomList.Count; i++)
        //{
        //    PercentBool += a_RandomList[i].Percent;
        //}// for(int i=0; i<World_RandomChapterList.Count; i++)

        

        //랜덤챕터리스트가 100퍼센트일때 만 들어옴

        int ResultSel = 0;
        //float Calc = 0.0f;
        float CompareResult = 0.0f;

        float PercentBool = 0.0f;
        
        if (GameManager.instance.ChaptManager.NowChapter.IsClear == false)
        {
            //Debug.Log("한번만 들어와야됩니다");
            //Debug.Log("설마여기");
            for (int i = 0; i < a_RandomList.Count; i++)
            {
                PercentBool += a_RandomList[i].Percent;
            }

            GameManager.instance.ChaptManager.NowChapter.IsClear = true;
        }
        else if(GameManager.instance.ChaptManager.NowChapter.IsClear == true)
        {
           // Debug.Log("9번들어와야됩니다");
           
            for (int i = 0; i < GameManager.instance.ChaptManager.NowChapter.Chapter_StageList.Count; i++)
            {
                for (int j = 0; j < a_RandomList.Count; j++)
                {
                    if (GameManager.instance.ChaptManager.NowChapter.Chapter_StageList[i].Stageid == a_RandomList[j].ID)
                    {
                        a_RandomList.RemoveAt(j);


                    }
                }
            }

          //  Debug.Log(a_RandomList.Count + "ListCount");

            int a_Count = a_RandomList.Count;
           // Debug.Log(a_Count);
          
            for (int i = 0; i < a_Count; i++)
            {   
               
                PercentBool += a_RandomList[i].Percent;
            }

          //  Debug.Log(PercentBool + "확인1111");
        }
        
       
        for (int i = 0; i < a_WorldListCount; i++)
        {
          

                float rand = Random.Range(0.0f, PercentBool);
            //Debug.Log("rand" + rand);
            CompareResult += a_RandomList[i].Percent;

            if (rand <= CompareResult)
            {

                //이때넣어준다
                ResultSel = a_RandomList[i].ID;
                //Debug.Log("Result:" + ResultSel);

                return ResultSel;
               
            }//if (rand <=CompareResult )

           

        }// for (int i = 0; i < a_WorldListCount; i++)
       
        return ResultSel;
    }

}
