using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class WorldInfoSerialization<T>
{

    public WorldInfoSerialization(List<T> _WorldSheet) => WorldSheet = _WorldSheet;

    public List<T> WorldSheet;
}

[System.Serializable]
public class WorldInfo : MonoBehaviour
{

    public int Worldid;
    public string WorldName;
    //인게임에서 사용(진행중인 월드가 없으면 리셋)
    //진행중이라면 저장해야하는 데이터

    public WorldInfo() { }

    public WorldInfo(int worldid, string worldName, List<PercentInfo> world_RandomChapterList)
    {
        Worldid = worldid;
        WorldName = worldName;
        World_RandomChapterList = world_RandomChapterList;
    }

    public List<ChapterInfo> World_ChapterList = new List<ChapterInfo>();
    public List<PercentInfo> World_RandomChapterList = new List<PercentInfo>();

    //마지막 챕터의 id
    public int EndChater;
    //월드 진행도
    public float WorldProgress;
    
}
