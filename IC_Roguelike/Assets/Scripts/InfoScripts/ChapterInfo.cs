using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChapterInfo : MonoBehaviour
{
    public int Chapterid;
    public string ChapterName;
    //인게임에서 사용(진행중인 월드가 없으면 리셋)
    //진행중이라면 저장해야 하는 데이터
    public List<StageInfo> Chapter_StageList = new List<StageInfo>();

    public List<PercentInfo> Chapter_MapList = new List<PercentInfo>();

    public List<PercentInfo> Chapter_MonsterList = new List<PercentInfo>();
    public List<PercentInfo> Chapter_ObjectList = new List<PercentInfo>();
    public int maxObjAmount;
    public List<int> diffcultyMode = new List<int>();
    public bool IsClear = false;
   
     
    
}
