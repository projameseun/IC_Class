using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class WorldInfo
{
    public int Worldid;     //월드 id값
    public string WorldName;    //월드종류 이름값
    public string Wolrd_RandomChapter;


     public WorldInfo() { }

    public WorldInfo(int worldid, string worldName, List<PercentInfo> world_RandomChapterList)
    {
        Worldid = worldid;
        WorldName = worldName;
        //World_RandomChapterList = world_RandomChapterList;
    }


    //인게임에서 사용(진행중인 월드가 없으면 리셋)
    //진행중이라면 저장해야하는 데이터
    //해당월드의 챕터 구성리스트(화염챕터1 화염챕터)
    [Header("챕터리스트")]
    public List<ChapterInfo> World_ChapterList = new List<ChapterInfo>();

    ////해당월드를 구성할수 있는 챕터리스트
    public List<PercentInfo> World_RandomChapterList;

    //마지막 챕터의 id
      
    
    public int ChapterProgress; //월드에서 지금 챕터가 어떤게 저장되잇는지
    public bool ExitChapter = false;    //챕터 그냥나갔을때
    public int EndChapter;  //마지막챕터장 나중에할거 
    public bool isChapter;
    public bool isWorldClear;    //이미클리어되었는가
    public bool isChapterClear; //챕터를 깨고나왓다면
}
