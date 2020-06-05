using System.Collections.Generic;
using UnityEngine;
using System.IO;


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

        float PercentBool = 0;
        for (int i = 0; i < a_RandomList.Count; i++)
        {
            PercentBool += a_RandomList[i].Percent;
        }// for(int i=0; i<World_RandomChapterList.Count; i++)

        //랜덤챕터리스트가 100퍼센트가 아니면 생성안함
        if (PercentBool != 100.0f)
        {
            Debug.Log("Not 100%" + PercentBool);
            return 0;
        }// if(PercentBool != 100.0f)

        //랜덤챕터리스트가 100퍼센트일때 만 들어옴

        int ResultSel = 0;
        //float Calc = 0.0f;
        float CompareResult = 0.0f;

        for (int i = 0; i < a_WorldListCount; i++)
        {

            float rand = Random.Range(0.0f, 100.0f);
            //Debug.Log("rand" + rand);
            CompareResult += a_RandomList[i].Percent;

            if (rand <= CompareResult)
            {
                //이때넣어준다
                ResultSel = i + 1;
                //Debug.Log("Result:" + ResultSel);

                return ResultSel;
            }//if (rand <=CompareResult )

        }// for (int i = 0; i < a_WorldListCount; i++)
        return ResultSel;

    }//public int  RandomSelcet()
}
