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
    public List<ChapterInfo> World_ChapterList = new List<ChapterInfo>();

    ////해당월드를 구성할수 있는 챕터리스트
    public List<PercentInfo> World_RandomChapterList;

    //마지막 챕터의 id
    public int EndChater;
    //월드 진행도
    public float WorldProgress;

    public bool isChapter;
}
